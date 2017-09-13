using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BankAccountDataAccess;
using BankAccountWeb.Controllers;
using NUnit.Framework;

namespace WebUnitTests
{
    [TestFixture]
    public class BankControllerTests
    {
        [Test]
        public void GivenFourAccounts_WhenTheAccountsAreListed_ThenFourAreListed()
        {
            //var controller = new BankController(dao);
            //var result = (ViewResult) controller.Index();
            //var model = (IList<IAccount>)result.Model;

            //Assert.That(model.Count, Is.EqualTo(4));
        }
    }
}
