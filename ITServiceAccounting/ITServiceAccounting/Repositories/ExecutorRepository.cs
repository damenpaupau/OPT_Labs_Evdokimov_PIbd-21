using ITServiceAccounting.interfaces;
using ITServiceAccounting.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITServiceAccounting.Repositories
{
    public class ExecutorRepository : IExecutorRepository
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public ExecutorRepository(DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Executor executor)
        {
            try
            {
                _logger.Information("Добавление исполнителя: Id={Id}, FullName={FullName}",
                    executor.Id, executor.FullName);

                _context.Executors.Add(executor);
                _context.SaveChanges();

                _logger.Information("Исполнитель успешно сохранён: Id={Id}", executor.Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Ошибка при добавлении исполнителя: FullName={FullName}", executor?.FullName);
                throw;
            }
        }

        public List<Executor> GetAll()
        {
            _logger.Information("Получение списка всех исполнителей");
            return _context.Executors.OrderBy(e => e.FullName).ToList();
        }

        public Executor GetById(Guid id)
        {
            _logger.Information("Поиск исполнителя по Id={Id}", id);
            return _context.Executors.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Executor executor)
        {
            try
            {
                _logger.Information("Обновление исполнителя: Id={Id}, FullName={FullName}",
                    executor.Id, executor.FullName);

                _context.Executors.Update(executor);
                _context.SaveChanges();

                _logger.Information("Исполнитель обновлён: Id={Id}", executor.Id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Ошибка при обновлении исполнителя: Id={Id}", executor?.Id);
                throw;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                _logger.Information("Удаление исполнителя: Id={Id}", id);
                var entity = _context.Executors.FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    _context.Executors.Remove(entity);
                    _context.SaveChanges();
                    _logger.Information("Исполнитель удалён: Id={Id}", id);
                }
                else
                {
                    _logger.Warning("Исполнитель для удаления не найден: Id={Id}", id);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Ошибка при удалении исполнителя: Id={Id}", id);
                throw;
            }
        }
    }
}