using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITServiceAccounting.Models
{
    public class ContractService
    {
        [Key]
        [Column("id")]
        public Guid Id { get; internal set; }

        [Required]
        [Column("contract_id")]
        public Guid ContractId { get; internal set; }

        [ForeignKey(nameof(ContractId))]
        public Contract Contract { get; internal set; }

        [Required]
        [Column("service_id")]
        public Guid ServiceId { get; internal set; }

        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; internal set; }

        // Пустой конструктор для EF Core
        protected ContractService() { }

        private ContractService(Guid id, Contract contract, Service service)
        {
            Id = id;
            Contract = contract;
            ContractId = contract.Id;
            Service = service;
            ServiceId = service.Id;
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