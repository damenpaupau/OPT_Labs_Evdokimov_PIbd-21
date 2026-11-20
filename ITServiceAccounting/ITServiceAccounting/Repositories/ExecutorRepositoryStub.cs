using ITServiceAccounting.interfaces;
using ITServiceAccounting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.Repositories
{
    // Заглушка
    public class ExecutorRepositoryStub : IExecutorRepository
    {
        private readonly List<Executor> _executors = new List<Executor>();

        public void Add(Executor executor)
        {
            if (executor == null) throw new ArgumentNullException(nameof(executor));
            _executors.Add(executor);
        }

        public List<Executor> GetAll()
        {
            return _executors.ToList();
        }

        public Executor GetById(Guid id)
        {
            return _executors.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Executor executor)
        {
            var existing = GetById(executor.Id);
            if (existing != null)
            {
                // Обновляем данные 
                existing.Update(executor.FullName, executor.Position);
            }
        }

        public void Delete(Guid id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                _executors.Remove(existing);
            }
        }
    }
}
