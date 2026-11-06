using ITServiceAccounting.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.Models
{
    // Справочник услуг
    public class Service
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal BaseCost { get; private set; }
        public ServiceCategory Category { get; private set; }

        private Service(Guid id, string name, decimal baseCost, ServiceCategory category)
        {
            Id = id;
            Name = name;
            BaseCost = baseCost;
            Category = category;
        }

        public static Service Create(string name, decimal baseCost, ServiceCategory category)
        {
            Validate(name, baseCost);
            return new Service(Guid.NewGuid(), name, baseCost, category);
        }

        // Метод обновления для формы редактирования справочника
        public void Update(string name, decimal baseCost, ServiceCategory category)
        {
            Validate(name, baseCost);
            Name = name;
            BaseCost = baseCost;
            Category = category;
        }

        private static void Validate(string name, decimal baseCost)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название услуги не может быть пустым.", nameof(name));
            if (baseCost < 0)
                throw new ArgumentException("Базовая стоимость не может быть отрицательной.", nameof(baseCost));
        }
    }
}
