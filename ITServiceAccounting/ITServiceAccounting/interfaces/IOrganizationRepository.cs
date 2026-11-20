using ITServiceAccounting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.interfaces
{
    // Интерфейс репозитория
    public interface IOrganizationRepository
    {
        void Add(Organization organization);
        List<Organization> GetAll();
        Organization GetById(Guid id);
        void Update(Organization organization);
        void Delete(Guid id);
    }
}
