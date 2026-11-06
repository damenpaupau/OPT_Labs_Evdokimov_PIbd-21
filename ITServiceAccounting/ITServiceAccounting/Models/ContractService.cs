using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.Models
{
    // Класс-связка многие-ко-многим
    public class ContractService
    {
        public Guid Id { get; private set; }
        public Contract Contract { get; private set; }
        public Service Service { get; private set; }

        private ContractService(Guid id, Contract contract, Service service)
        {
            Id = id;
            Contract = contract;
            Service = service;
        }

        public static ContractService Create(Contract contract, Service service)
        {
            if (contract == null)
                throw new ArgumentNullException(nameof(contract), "Договор не может быть пустым.");
            if (service == null)
                throw new ArgumentNullException(nameof(service), "Услуга не может быть пустой.");

            return new ContractService(Guid.NewGuid(), contract, service);
        }
    }
}
