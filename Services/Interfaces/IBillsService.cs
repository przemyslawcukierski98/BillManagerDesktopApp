using System.Collections.Generic;

namespace BillManagerWPF.Services.Interfaces
{
    public interface IBillsService
    {
        IEnumerable<Bill> GetBillsForUser(string userName);
        bool Add(Bill bill);
        bool Edit(Bill bill);
    }
}
