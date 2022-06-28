using Hospital_patientCRUD_.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_patientCRUD_.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            var db = new Entities();
            var patients = db.Patients.ToList();
            return View(patients);
        }
        //------------------------------------------
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Patient());
        }
        [HttpPost]
        public ActionResult Create(Patient p)
        {

            if (ModelState.IsValid)
            {
                var db = new Entities();
                db.Patients.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        //------------------------------------------
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new Entities();
            var patient = (from p in db.Patients
                           where p.Id == Id
                           select p).FirstOrDefault();
            return View(patient);
        }

        [HttpPost]
        public ActionResult Edit(Patient p)
        {
            var db = new Entities();
            var data = (from pt in db.Patients
                        where pt.Id.Equals(p.Id)
                        select pt).FirstOrDefault();

            db.Entry(data).CurrentValues.SetValues(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //------------------------------------------
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var db = new Entities();
            var patient = (from p in db.Patients
                           where p.Id == Id
                           select p).FirstOrDefault();
            return View(patient);
        }

        [HttpPost]
        public ActionResult Delete(Patient p)
        {
            var db = new Entities();
            var patient = (from pt in db.Patients
                        where pt.Id == p.Id
                        select pt).FirstOrDefault();

            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}