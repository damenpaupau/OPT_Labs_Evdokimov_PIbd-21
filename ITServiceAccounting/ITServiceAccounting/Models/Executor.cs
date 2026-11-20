using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITServiceAccounting.Models
{
    public class Executor
    {
        [Key]
        [Column("id")]
        public Guid Id { get; internal set; }

        [Required]
        [MaxLength(255)]
        [Column("full_name")]
        public string FullName { get; internal set; }

        [Required]
        [MaxLength(255)]
        [Column("position")]
        public string Position { get; internal set; }

        // Навигационное свойство для связи 1:N с договорами
        public ICollection<Contract> Contracts { get; internal set; } = new List<Contract>();

        // Пустой конструктор для EF Core
        protected Executor() { }

        private Executor(Guid id, string fullName, string position)
        {
            Id = id;
            FullName = fullName;
            Position = position;
        }

        public static Executor Create(string fullName, string position)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("ФИО исполнителя не может быть пустым.", nameof(fullName));

            if (string.IsNullOrWhiteSpace(position))
                throw new ArgumentException("Должность не может быть пустой.", nameof(position));

            return new Executor(Guid.NewGuid(), fullName, position);
        }

        public void Update(string fullName, string position)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("ФИО исполнителя не может быть пустым.", nameof(fullName));

            if (string.IsNullOrWhiteSpace(position))
                throw new ArgumentException("Должность не может быть пустой.", nameof(position));

            FullName = fullName;
            Position = position;
        }
    }
}