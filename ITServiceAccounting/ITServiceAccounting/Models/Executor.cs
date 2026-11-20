using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.Models
{
    // Исполнитель
    public class Executor
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Position { get; private set; }

        private Executor(Guid id, string fullName, string position)
        {
            Id = id;
            FullName = fullName;
            Position = position;
        }

        // Cтатический метод создания объекта
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
