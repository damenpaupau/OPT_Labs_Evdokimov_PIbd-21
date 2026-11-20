using ITServiceAccounting.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.Models
{
    // Операция: Договор
    public class Contract
    {
        public Guid Id { get; private set; }
        public decimal TotalAmount { get; private set; }

        // Сроки: дата начала
        public DateTime StartDate { get; private set; }

        // Сроки: дата окончания
        public DateTime EndDate { get; private set; }

        // Ссылка на организацию
        public Organization Client { get; private set; }

        // Ссылка на исполнителя
        public Executor ResponsibleExecutor { get; private set; } 
        public ContractStatus Status { get; private set; }

        private Contract(Guid id, decimal totalAmount, DateTime startDate, DateTime endDate,
                         Organization client, Executor executor, ContractStatus status)
        {
            Id = id;
            TotalAmount = totalAmount;
            StartDate = startDate;
            EndDate = endDate;
            Client = client;
            ResponsibleExecutor = executor;
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
