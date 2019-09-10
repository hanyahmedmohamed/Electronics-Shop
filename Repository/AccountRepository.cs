using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task2.Models;

namespace Task2.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private myDemEntities myDemEntities = new myDemEntities();



        public void create(Account account)
        {
            myDemEntities.Accounts.Add(account);
            myDemEntities.SaveChanges();
        }


        public Account login(string username, string password)
        {
            try
            {
                return myDemEntities.Accounts.Single(account => account.userName.Equals(username) && account.password.Equals(password));
            }
            catch
            {
                return null;
            }
        }
    }
}