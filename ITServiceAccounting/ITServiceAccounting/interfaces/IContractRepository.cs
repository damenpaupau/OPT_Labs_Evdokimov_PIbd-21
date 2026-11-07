using ITServiceAccounting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.interfaces
{
    // Репозиторий для операции Contract
    public interface IContractRepository
    {
        void Add(Contract contract);
        List<Contract> GetAll();
        Contract GetById(Guid id);
        void Delete(Guid id);
    }
}
