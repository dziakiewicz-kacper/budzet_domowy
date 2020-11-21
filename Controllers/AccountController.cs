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
        private Account account = null;
        public ActionResult Index()
        {
            if (Session["login"] == null || TempData["account"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            account = TempData["account"] as Account;
            ViewBag.Account = account;
            return View(ViewBag.Account);
        }
        public ActionResult Logout()
        {
            Session["login"] = null;
            account = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult ShowExamples(int id = 100)
        {
            ViewBag.Count = id;
            return View();
        }
    }
}