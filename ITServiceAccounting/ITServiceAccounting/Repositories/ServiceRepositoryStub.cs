using ITServiceAccounting.interfaces;
using ITServiceAccounting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.Repositories
{
    // Заглушка
    public class ServiceRepositoryStub : IServiceRepository
    {
        private readonly List<Service> _services = new List<Service>();

        public void Add(Service service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            _services.Add(service);
        }

        public List<Service> GetAll()
        {
            return _services.ToList();
        }

        public Service GetById(Guid id)
        {
            return _services.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Service service)
        {
            var existing = GetById(service.Id);
            if (existing != null)
            {
                existing.Update(service.Name, service.BaseCost, service.Category);
            }
        }

        public void Delete(Guid id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                _services.Remove(existing);
            }
        }
    }
}
