using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task2.Models;
using Task2.Repository;

namespace Task2.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository iAccountRepository = new AccountRepository();

        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public ActionResult Register(Account account)
        {
            iAccountRepository.create(account);
            return RedirectToAction("MyAccount", "Account");
        }


        [HttpGet]
        public ActionResult MyAccount()
        {
            return View("MyAccount");
        }
        [HttpPost]
        public ActionResult MyAccount(Account account)
        {
            Account acc = iAccountRepository.login(account.userName, account.password);
            if (acc == null)
            {
                ViewBag.error = "Account 's Invalid";
                return View("MyAccount");
            }
            else
            {
                Session["username"] = acc.userName;
                return View("Welcome");
            }
            
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("username");
            return RedirectToAction("MyAccount", "Account");
        }
	}
}