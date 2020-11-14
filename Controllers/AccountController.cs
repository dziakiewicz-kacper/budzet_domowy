using BudzetDomowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudzetDomowy.Controllers
{
    public class AccountController : Controller
    {
        static List<Account> accounts = new List<Account>();
        // GET: Account
        public ActionResult Index()
        {
            accounts = Account.Examples(100);
            return View();
        }
        [HttpGet]
        public ActionResult ShowExamples(int id)
        {
            ViewBag.List = accounts;
            ViewBag.Count = id;
            return View();
        }
    }
}