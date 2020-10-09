using System.Collections.Generic;

namespace BillManagerWPF.Services.Interfaces
{
    interface IBillsService
    {
        IEnumerable<Bill> GetBillsForUser(string userName);
        bool Add(Bill bill);
        bool Edit(Bill bill);
    }
}
