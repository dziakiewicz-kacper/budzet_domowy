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
        public static Account account;
        public ActionResult Index()
        {
            if (account != null)
            {
                return RedirectToAction("Index", "Account");
            }
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
                    Session["LoginResult"] = false;
                    return Redirect(Url.Action("Index", "Login"));
                }
                Account account1 = new Account();
                account1.ID = id;
                account1.ReadAccount();
                Session["login"] = true;
                account = account1;
                return RedirectToAction("Index", "Account");
            }
            return Redirect(Url.Action("Index", "Account"));
        }
        [HttpPost]
        public ActionResult Register()
        {
            int id;
            string firstName = Request.Form[0];
            string lastName = Request.Form[1];
            string mail = Request.Form[2];
            string password = Request.Form[3];
            string number = Request.Form[5];
            string street = Request.Form[4];
            string town = Request.Form[6];
            string zipCode = Request.Form[7];
            bool isExist = Login.CheckIsExist(mail);
            if (isExist == true)
            {
                Session["RegisterResult"] = "isExist";
            } else
            {
                Account account2 = new Account();
                DateTime dateOfBirth = new DateTime(1990, 12, 12);
                Person person = new Person(firstName, lastName, dateOfBirth);
                Login login = new Login(mail, password);
                Address address = new Address(street,zipCode,number,town);
                person.SetAddress(address);
                account2.SetLogin(login);
                account2.SetPerson(person);
                account2.InsertAccount();
                Session["RegisterResult"] = "CreateAccount";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            Session["login"] = null;
            return Redirect(Url.Action("Index", "Login"));
        }
    }
}