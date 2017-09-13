using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount;
using BankAccountDataAccess;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var dao = new BankDAO();
            var currentAccount = new CurrentAccount(dao, null);

            var limit = currentAccount.GetWithdrawalLimt(1);

            Console.WriteLine(limit);
        }
    }

    internal interface ITime
    {
        DateTime CurrentTime();
    }

    internal class SystemTime : ITime
    {
        public DateTime CurrentTime()
        {
            return DateTime.Now;
        }
    }
}
