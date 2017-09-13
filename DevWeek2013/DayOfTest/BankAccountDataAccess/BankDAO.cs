using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountDataAccess
{
    public interface IBankDAO
    {
        IAccount GetAccount(int id);
        IList<IAccount> GetAccounts();
    }

    public class BankDAO : IBankDAO
    {
        public IAccount GetAccount(int id)
        {
            // access the database
            return new Account();
        }

        public IList<IAccount> GetAccounts()
        {
            return new List<IAccount> { new Account { Name = "Current" }, new Account { Name = "Savings" }, new Account { Name = "Escape Fund" } };
        }
    }

    public interface IAccount
    {
        int GetLimit();
        string Name { get; set; }
    }

    public class Account : IAccount
    {
        public string Name { get; set; }
        public int GetLimit()
        {
            return 100;
        }
    }
}
