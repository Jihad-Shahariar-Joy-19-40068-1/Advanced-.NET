using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication7.Models;

namespace MvcApplication7.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public ActionResult Index()
        {
            var people = new List<Student>();
            for (int i = 1; i <= 10; i++)
            {
                people.Add(
                    new Student()
                    {
                        id = "19-40068-1",
                        name = "Person " + i,
                        dob = "12.12.12"
                    }
                 );
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student st)
        {
            /*ViewBag.Name = form["Name"];
            ViewBag.Id = form["Id"];
            ViewBag.Dob = form["Dob"];*/
            /*ViewBag.Name = Request["Name"];
            ViewBag.Id = Request["Id"];
            ViewBag.Dob = Request["Dob"];*/
            /*ViewBag.Name = Name;
            ViewBag.Id = Id;
            ViewBag.Dob =Dob;*/
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(st);
        }
        public ActionResult Submit()
        {
            return View();
        }

    }
}
