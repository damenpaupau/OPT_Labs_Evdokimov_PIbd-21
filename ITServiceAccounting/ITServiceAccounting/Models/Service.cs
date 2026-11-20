using ITServiceAccounting.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITServiceAccounting.Models
{
    public class Service
    {
        [Key]
        [Column("id")]
        public Guid Id { get; internal set; }

        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; internal set; }

        [Required]
        [Column("base_cost", TypeName = "numeric(18,2)")]
        public decimal BaseCost { get; internal set; }

        [Required]
        [Column("category")]
        public ServiceCategory Category { get; internal set; }

        // Навигационное свойство для связи N:M через промежуточную таблицу
        public ICollection<ContractService> ContractServices { get; internal set; } = new List<ContractService>();

        // Пустой конструктор для EF Core
        protected Service() { }

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