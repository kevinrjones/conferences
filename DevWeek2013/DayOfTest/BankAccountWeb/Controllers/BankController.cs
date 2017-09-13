using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankAccountDataAccess;

namespace BankAccountWeb.Controllers
{
    public class BankController : Controller
    {
        //
        // GET: /Bank/
        private IBankDAO _dao;

        public BankController(IBankDAO dao)
        {
            _dao = dao;
        }

        public ActionResult Index()
        {
            var accounts = _dao.GetAccounts();
            // NEVER, EVER DO THIS!!!!!!!!!!!!!
            return View(accounts);
        }

    }
}
