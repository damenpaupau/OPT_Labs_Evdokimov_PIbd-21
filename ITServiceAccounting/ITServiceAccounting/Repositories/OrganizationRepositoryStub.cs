using ITServiceAccounting.interfaces;
using ITServiceAccounting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.Repositories
{
    // Класс-заглушки
    public class OrganizationRepositoryStub : IOrganizationRepository
    {
        // Временное хранилище данных в оперативной памяти
        private readonly List<Organization> _organizations = new List<Organization>();

        public void Add(Organization organization)
        {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            _organizations.Add(organization);
        }

        public List<Organization> GetAll()
        {
            // Возвращаем копию списка

            return _organizations.ToList(); 
        }

        public Organization GetById(Guid id)
        {
            return _organizations.FirstOrDefault(o => o.Id == id);
        }

        public void Update(Organization organization)
        {
            var existing = GetById(organization.Id);
            if (existing != null)
            {
                // Обновляем данные через метод Update
                existing.Update(organization.Name, organization.Inn, organization.ContactPerson);
            }
        }

        public void Delete(Guid id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                _organizations.Remove(existing);
            }
        }
    }
}
