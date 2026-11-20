using ITServiceAccounting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITServiceAccounting.Models
{
    public class Contract
    {
        [Key]
        [Column("id")]
        public Guid Id { get; internal set; }

        [Required]
        [Column("total_amount", TypeName = "numeric(18,2)")]
        public decimal TotalAmount { get; internal set; }

        [Required]
        [Column("start_date", TypeName = "date")]
        public DateTime StartDate { get; internal set; }

        [Required]
        [Column("end_date", TypeName = "date")]
        public DateTime EndDate { get; internal set; }

        [Required]
        [Column("status")]
        public ContractStatus Status { get; internal set; }

        [Required]
        [Column("organization_id")]
        public Guid OrganizationId { get; internal set; }

        [ForeignKey(nameof(OrganizationId))]
        public Organization Client { get; internal set; }

        [Required]
        [Column("executor_id")]
        public Guid ExecutorId { get; internal set; }

        [ForeignKey(nameof(ExecutorId))]
        public Executor ResponsibleExecutor { get; internal set; }

        // Навигационное свойство для связи N:M с услугами
        public ICollection<ContractService> ContractServices { get; internal set; } = new List<ContractService>();

        // Пустой конструктор для EF Core
        protected Contract() { }

        private Contract(Guid id, decimal totalAmount, DateTime startDate, DateTime endDate,
                         Organization client, Executor executor, ContractStatus status)
        {
            Id = id;
            TotalAmount = totalAmount;
            StartDate = startDate;
            EndDate = endDate;
            Client = client;
            OrganizationId = client.Id;
            ResponsibleExecutor = executor;
            ExecutorId = executor.Id;
            Status = status;
        }

        public static Contract Create(decimal totalAmount, DateTime startDate, DateTime endDate,
                                      Organization client, Executor executor, ContractStatus status)
        {
            if (totalAmount < 0)
                throw new ArgumentException("Сумма договора не может быть отрицательной.", nameof(totalAmount));
            if (endDate < startDate)
                throw new ArgumentException("Дата окончания не может быть раньше даты начала.", nameof(endDate));
            if (client == null)
                throw new ArgumentNullException(nameof(client), "Организация-заказчик должна быть указана.");
            if (executor == null)
                throw new ArgumentNullException(nameof(executor), "Ответственный исполнитель должен быть указан.");

            return new Contract(Guid.NewGuid(), totalAmount, startDate, endDate, client, executor, status);
        }

        public void ChangeStatus(ContractStatus newStatus)
        {
            Status = newStatus;
        }
    }
}