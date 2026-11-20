using ITServiceAccounting.interfaces;
using ITServiceAccounting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.Repositories
{
    // Заглушка
    public class ContractRepositoryStub : IContractRepository
    {
        private readonly List<Contract> _contracts = new List<Contract>();

        public void Add(Contract contract)
        {
            if (contract == null) throw new ArgumentNullException(nameof(contract));
            _contracts.Add(contract);
        }

        public List<Contract> GetAll()
        {
            return _contracts.ToList();
        }

        public Contract GetById(Guid id)
        {
            return _contracts.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(Guid id)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                _contracts.Remove(existing);
            }
        }
    }
}
