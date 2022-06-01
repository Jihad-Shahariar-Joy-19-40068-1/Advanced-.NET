using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models;

namespace Lab2.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Profile()
        {

            Person pr = new Person()
            {
                Id = "19-40068-1",
                Name = "Jihad Shahariar Joy",
                Dob = "27/11/2000"
            };
            return View(pr);
        }

        // GET: Person
        /*public ActionResult Index()
        {
            ViewBag.Name = "Sabbir";
            return View();
        }*/

        /*public ActionResult Register()
        {
            //return Redirect("/person/profile");
            TempData["msg"] = "Registration UnSuccessfull";
            return RedirectToAction("Profile");
            //return RedirectToAction("Index", "Home");
            //return View();
        }*/
        public ActionResult Index()
        {
            TempData["msg"] = "Registration Successfull";
            return RedirectToAction("Profile");
        }
    }
}