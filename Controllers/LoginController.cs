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
        public Account account = null;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PerformLogin(string login, string password)
        {
            if (Session["user"] == null)
            {
                int id;
                Session["ResultLogin"] = null;
                if (Account.VerifyAccount(out id, login, password) == false)
                {
                    Session["ResultLogin"] = "False";
                    return Redirect(Url.Action("Index", "Login"));
                }
                account = Account.SearchAccount(id);
                Session["user"] = account.Person.FirstName;
                return Redirect(Url.Action("Index", "Login"));
            }
            return Redirect(Url.Action("Index", "Login"));
        }
        public ActionResult Logout()
        {
            account = null;
            Session["user"] = null;
            return Redirect(Url.Action("Index", "Login"));
        }
    }
}