using BillManagerWPF.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillManagerWPF.Services.Implementations
{
    public class BillsService : IBillsService
    {
        private readonly BillManagerDBEntities context;
        public BillsService(BillManagerDBEntities context)
        {
            this.context = context;
        }

        public bool Add(Bill bill)
        {
            try
            {
                context.Bill.Add(bill);
                context.SaveChanges();
            }
            catch(Exception exception)
            {
                return false;
            }
            return true;
        }

        public bool Edit(Bill bill)
        {
            var billDatabase = context.Bill.Where(bills => bills.Id == bill.Id).SingleOrDefault();

            if(billDatabase == null)
            {
                return false;
            }

            try
            {
                billDatabase.BillName = bill.BillName;
                billDatabase.April = bill.April;
                billDatabase.August = bill.August;
                billDatabase.BillsYear = bill.BillsYear;
                billDatabase.December = bill.December;
                billDatabase.February = bill.February;
                billDatabase.January = bill.January;
                billDatabase.July = bill.July;
                billDatabase.June = bill.June;
                billDatabase.March = bill.March;
                billDatabase.May = bill.May;
                billDatabase.November = bill.November;
                billDatabase.October = bill.October;
                billDatabase.September = bill.September;
                context.SaveChanges();
            }
            catch(Exception exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Bill> GetBillsForUser(string userName)
        {
            var userId = context.Users.Where(users => users.Username == userName).FirstOrDefault().Id;
            return context.Bill.Where(bills => bills.Users.Username == userName);
        }
    }
}
