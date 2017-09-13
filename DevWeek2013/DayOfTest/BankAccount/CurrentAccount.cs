using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BankAccountDataAccess;

namespace BankAccount
{
    public class CurrentAccount
    {
        public int Balance { get; set; }
        private bool _isOpen;
        private readonly IBankDAO _dao;
        private readonly ILogger _logger;

        public CurrentAccount(IBankDAO dao, ILogger logger)
        {
            _dao = dao;
            _logger = logger;
        }

        protected void SetupAccount()
        {
        }

        public int GetWithdrawalLimt(int accountId)
        {
            IAccount account;
            
            try
            {
                account = _dao.GetAccount(accountId);
            }
            catch (Exception e)
            {
                
                throw new BankAccountException("",e);
            }
            return account.GetLimit();
        }

        public void Open(int amount)
        {
            _logger.LogMessage("Try to open account");
            if (_isOpen)
            {
                throw new InvalidStateException();
            }
            Balance = amount;
            _isOpen = true;
        }

        public void Withdraw(int amount)
        {
            Balance -= amount;
        }

        internal int GetBalance()
        {
            // do something complex
            return Balance;
        }
    }

    public interface ILogger
    {
        void LogMessage(string message);
    }

    [Serializable]
    public class BankAccountException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public BankAccountException()
        {
        }

        public BankAccountException(string message) : base(message)
        {
        }

        public BankAccountException(string message, Exception inner) : base(message, inner)
        {
        }

        protected BankAccountException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
