using System.Collections.Generic;

namespace BillManagerWPF.Services.Interfaces
{
    interface IInfoService
    {
        IEnumerable<Information> GetAllForUser(string username);
        bool AddInformation(Information information);
        string GetInformationStringByUser(string username);
    }
}
