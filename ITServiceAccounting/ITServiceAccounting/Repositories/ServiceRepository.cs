using ITServiceAccounting.interfaces;
using ITServiceAccounting.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITServiceAccounting.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public ServiceRepository(DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Service service)
        {
            try
            {
                _logger.Information("Добавление услуги: Id={Id}, Name={Name}, BaseCost={BaseCost}",
                    service.Id, service.Name, service.BaseCost);

                _context.Services.Add(service);
                _context.SaveChanges();

                _logger.Information("Услуга успешно сохранена: Id={Id}", service.Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Ошибка при добавлении услуги: Name={Name}", service?.Name);
                throw;
            }
        }

        public List<Service> GetAll()
        {
            _logger.Information("Получение списка всех услуг");
            return _context.Services.OrderBy(s => s.Name).ToList();
        }

        public Service GetById(Guid id)
        {
            _logger.Information("Поиск услуги по Id={Id}", id);
            return _context.Services.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Service service)
        {
            try
            {
                _logger.Information("Обновление услуги: Id={Id}, Name={Name}, BaseCost={BaseCost}",
                    service.Id, service.Name, service.BaseCost);

                _context.Services.Update(service);
                _context.SaveChanges();

                _logger.Information("Услуга обновлена: Id={Id}", service.Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Ошибка при обновлении услуги: Id={Id}", service?.Id);
                throw;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                _logger.Information("Удаление услуги: Id={Id}", id);
                var entity = _context.Services.FirstOrDefault(s => s.Id == id);
                if (entity != null)
                {
                    _context.Services.Remove(entity);
                    _context.SaveChanges();
                    _logger.Information("Услуга удалена: Id={Id}", id);
                }
                else
                {
                    _logger.Warning("Услуга для удаления не найдена: Id={Id}", id);
                }
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                _logger.Error(ex, "Ошибка при удалении услуги: Id={Id}", id);
                throw;
            }
        }
    }
}