using ITServiceAccounting.interfaces;
using ITServiceAccounting.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITServiceAccounting.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public OrganizationRepository(DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Organization organization)
        {
            try
            {
                _logger.Information("Добавление организации: Id={Id}, Name={Name}, Inn={Inn}",
                    organization.Id, organization.Name, organization.Inn);

                _context.Organizations.Add(organization);
                _context.SaveChanges();

                _logger.Information("Организация успешно сохранена: Id={Id}", organization.Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Ошибка при добавлении организации: Name={Name}", organization?.Name);
                throw;
            }
        }

        public List<Organization> GetAll()
        {
            _logger.Information("Получение списка всех организаций");
            return _context.Organizations.OrderBy(o => o.Name).ToList();
        }

        public Organization GetById(Guid id)
        {
            _logger.Information("Поиск организации по Id={Id}", id);
            return _context.Organizations.FirstOrDefault(o => o.Id == id);
        }

        public void Update(Organization organization)
        {
            try
            {
                _logger.Information("Обновление организации: Id={Id}, Name={Name}",
                    organization.Id, organization.Name);

                _context.Organizations.Update(organization);
                _context.SaveChanges();

                _logger.Information("Организация обновлена: Id={Id}", organization.Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Ошибка при обновлении организации: Id={Id}", organization?.Id);
                throw;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                _logger.Information("Удаление организации: Id={Id}", id);
                var entity = _context.Organizations.FirstOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    _context.Organizations.Remove(entity);
                    _context.SaveChanges();
                    _logger.Information("Организация удалена: Id={Id}", id);
                }
                else
                {
                    _logger.Warning("Организация для удаления не найдена: Id={Id}", id);
                }
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                _logger.Error(ex, "Ошибка при удалении организации: Id={Id}", id);
                throw;
            }
        }
    }
}