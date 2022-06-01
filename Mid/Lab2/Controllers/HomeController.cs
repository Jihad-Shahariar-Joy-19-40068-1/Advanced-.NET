using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        new public ActionResult Profile()
        {
            ViewBag.Name = "Joy";
            ViewBag.ID = "19-40068-1";

            ViewData["Name"] = "Joy";
            return View();
        }
        public ActionResult Register()
        {
            TempData["msg"] = "Registration Successful";
            //return Redirect("/person/profile");
            return RedirectToAction("Profile");
            //return RedirectToAction("Index", "Home");

        }
    }
}                                   