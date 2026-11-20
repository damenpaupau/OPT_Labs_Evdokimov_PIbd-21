using System;
using System.Collections.Generic;
using System.Text;

namespace ITServiceAccounting.Enums
{
    [Flags]

    // Статус договора
    public enum ContractStatus
    {
        None = 0,

        // Подписан
        Signed = 1,

        // В работе
        InProgress = 2,

        // Оплачен
        Paid = 4,

        // Завершен
        Completed = 8     
    }
}
