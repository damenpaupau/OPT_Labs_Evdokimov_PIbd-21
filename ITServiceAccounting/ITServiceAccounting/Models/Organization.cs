using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.Models
{
    // Справочник организаций
    public class Organization
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Inn { get; private set; }
        public string ContactPerson { get; private set; }

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

        // Метод обновления для формы редактирования справочника
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
