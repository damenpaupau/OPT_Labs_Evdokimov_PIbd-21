using ITServiceAccounting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.interfaces
{
    // Репозиторий для справочника Executor
    public interface IExecutorRepository
    {
        void Add(Executor executor);
        List<Executor> GetAll();
        Executor GetById(Guid id);
        void Update(Executor executor);
        void Delete(Guid id);
    }
}
