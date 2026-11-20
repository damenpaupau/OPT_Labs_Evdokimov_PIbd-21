using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITServiceAccounting.Models
{
    public class Organization
    {
        [Key]
        [Column("id")]
        public Guid Id { get; internal set; }

        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; internal set; }

        [Required]
        [MaxLength(20)]
        [Column("inn")]
        public string Inn { get; internal set; }

        [Required]
        [MaxLength(255)]
        [Column("contact_person")]
        public string ContactPerson { get; internal set; }

        // Навигационное свойство для связи 1:N с договорами
        public ICollection<Contract> Contracts { get; internal set; } = new List<Contract>();

        // Пустой конструктор для EF Core
        protected Organization() { }

        private Organization(Guid id, string name, string inn, string contactPerson)
        {
            Id = id;
            Name = name;
            Inn = inn;
            ContactPerson = contactPerson;
        }

        public static Organization Create(string name, string inn, string contactPerson)
        {
            Validate(name, inn, contactPerson);
            return new Organization(Guid.NewGuid(), name, inn, contactPerson);
        }

        public void Update(string name, string inn, string contactPerson)
        {
            Validate(name, inn, contactPerson);
            Name = name;
            Inn = inn;
            ContactPerson = contactPerson;
        }

        private static void Validate(string name, string inn, string contactPerson)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название организации не может быть пустым.", nameof(name));
            if (string.IsNullOrWhiteSpace(inn))
                throw new ArgumentException("ИНН не может быть пустым.", nameof(inn));
            if (string.IsNullOrWhiteSpace(contactPerson))
                throw new ArgumentException("Контактное лицо не может быть пустым.", nameof(contactPerson));
        }
    }
}