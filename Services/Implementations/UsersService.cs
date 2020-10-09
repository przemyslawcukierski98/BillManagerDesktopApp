using BillManagerWPF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillManagerWPF.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly BillManagerDBEntities context;
        public UsersService(BillManagerDBEntities context)
        {
            this.context = context;
        }

        public bool EditUser(Users user)
        {
            var userDatabase = context.Users.Where(u => u.Id == user.Id).SingleOrDefault();

            try
            {
                userDatabase.Username = user.Username;
                userDatabase.Surname = user.Surname;
                userDatabase.Password = user.Password;
                userDatabase.Email = user.Email;
                userDatabase.IsPaid = user.IsPaid;
            }
            catch(Exception exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Users> GetAll()
        {
            return context.Users.ToList();
        }

        public int GetUserIdByName(string username)
        {
            return context.Users.Where(users => users.Username == username).FirstOrDefault().Id;
        }

        public bool Login(Users user)
        {
            var allUsers = context.Users.ToList();
            if(context.Users.Where(users => users.Username == user.Username && users.Password == user.Password).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Register(Users user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            catch(Exception exception)
            {
                return false;
            }
            return true;
        }
    }
}
