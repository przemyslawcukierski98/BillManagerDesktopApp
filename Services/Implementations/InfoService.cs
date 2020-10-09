using BillManagerWPF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillManagerWPF.Services.Implementations
{
    public class InfoService : IInfoService
    {
        private readonly BillManagerDBEntities context;
        public InfoService(BillManagerDBEntities context)
        {
            this.context = context;
        }

        public bool AddInformation(Information information)
        {
            try
            {
                context.Information.Add(information);
                context.SaveChanges();
            }
            catch(Exception exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Information> GetAllForUser(string username)
        {
            return context.Information.Where(information => information.Users.Username == username);
        }

        public string GetInformationStringByUser(string username)
        {
            var informations = GetAllForUser(username);
            string result = "";

            foreach(Information info in informations)
            {
                result = $"{result}{info.InformationName}{Environment.NewLine}";
                result = $"{result}{info.Content}{Environment.NewLine}";
            }
            return result;
        }
    }
}
