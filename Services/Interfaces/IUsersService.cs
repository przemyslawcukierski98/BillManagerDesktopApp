using System.Collections.Generic;

namespace BillManagerWPF.Services.Interfaces
{
    interface IUsersService
    {
        bool Register(Users user);
        bool Login(Users user);
        bool EditUser(Users user);
        IEnumerable<Users> GetAll();
        int GetUserIdByName(string username);
    }
}
