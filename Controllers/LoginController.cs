using BudzetDomowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudzetDomowy.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PerformLogin(string login, string password)
        {
            if (Session["login"] == null)
            {
                int id;
                Session["ResultLogin"] = null;
                if (Account.VerifyAccount(out id, login, password) == false)
                {
                    return Redirect(Url.Action("Index", "Login"));
                }
                Account account = new Account(id);
                account.ReadAccount();
                Session["login"] = true;
                TempData["account"] = account;
                return RedirectToAction("Index", "Account");
            }
            return Redirect(Url.Action("Index", "Account"));
        }
        public ActionResult Logout()
        {
            Session["login"] = null;
            return Redirect(Url.Action("Index", "Login"));
        }
    }
}