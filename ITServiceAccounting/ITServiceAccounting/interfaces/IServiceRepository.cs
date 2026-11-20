using ITServiceAccounting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.interfaces
{
    // Репозиторий для справочника Service
    public interface IServiceRepository
    {
        void Add(Service service);
        List<Service> GetAll();
        Service GetById(Guid id);
        void Update(Service service);
        void Delete(Guid id);
    }
}
