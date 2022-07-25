using HMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View(new Registration());
        }
        [HttpPost]
        public ActionResult Registration(Registration r)
        {

            if (ModelState.IsValid)
            {
                HospitalEntities db = new HospitalEntities();
                db.Registrations.Add(r);
                db.SaveChanges();
                TempData["reg"] = "Registration Successful | Login To Continue";
                return RedirectToAction("Index", "Home");
            }
            return View(r);
        }

    }
}