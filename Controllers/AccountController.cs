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
        public ActionResult Index()
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(LoginController.account);
        }
        public ActionResult Logout()
        {
            Session["login"] = null;
            LoginController.account = null;
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