using Patient.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HMS.Controllers
{
    //[Authorize]     //[AllowAnonymous]
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            var db = new HospitalEntities();
            var notices = (from n in db.Notices
                           where n.Type == "P"
                           select n).ToList();

            return View(notices);
        }
        //----------------------------------------------------
        public ActionResult Profile()     //See Own Profile
        {
            var Id = Int32.Parse(Session["logged_user"].ToString());
            var db = new HospitalEntities();
            var patient = (from p in db.Registrations
                           where p.Id == Id && p.Type == "P"
                           select p).FirstOrDefault();
            return View(patient);
        }
        //----------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int Id)        //get value to edit
        {
            var db = new HospitalEntities();
            var patient = (from p in db.Registrations
                           where p.Id == Id && p.Type == "P"
                           select p).FirstOrDefault();
            return View(patient);
        }

        [HttpPost]
        public ActionResult Edit(Registration p)        //edit post
        {
            HospitalEntities db = new HospitalEntities();
            var data = (from pt in db.Registrations
                        where pt.Id == p.Id
                        select pt).FirstOrDefault();

            db.Entry(data).CurrentValues.SetValues(p);
            db.SaveChanges();
            return RedirectToAction("Profile", new RouteValueDictionary(new { Controller = "Patient", Action = "Profile", p.Id }));
        }
        //----------------------------------------------------
        [HttpGet]
        public ActionResult DoctorList()       //see all doctors
        {
            var db = new HospitalEntities();
            var alldoctors = (from d in db.Registrations
                              where d.Type == "D"
                              select d).ToList();

            //var patients = db.Registrations.ToList();
            return View(alldoctors);
        }
        //----------------------------------------------------
        [HttpGet]
        public ActionResult DoctorView(int Id)     //view one from list
        {
            var db = new HospitalEntities();
            var doctor = (from d in db.Registrations
                          where d.Id == Id && d.Type == "D"
                          select d).FirstOrDefault();
            return View(doctor);
        }
        //----------------------------------------------------
        [HttpGet]
        public ActionResult DonorApplication()          //Apply As a Donor view
        {
            var Id = Int32.Parse(Session["logged_user"].ToString());
            var db = new HospitalEntities();
            var patient = (from p in db.Registrations
                           where p.Id == Id && p.Type == "P"
                           select p).FirstOrDefault();
            return View(patient);
            //return View(new Donor(patient));
        }
        [HttpPost]
        public ActionResult DonorApplication(Donor d)       //Apply as a donor post
        {

            if (ModelState.IsValid)
            {
                HospitalEntities db = new HospitalEntities();
                db.Donors.Add(d);
                db.SaveChanges();
                TempData["D_app"] = "Application Processed | Wait for Doctor's Approval";
                return RedirectToAction("OwnDonations");
            }
            return View(d);
        }
        //----------------------------------------------------
        [HttpGet]
        public ActionResult OwnDonations()          //See Own Donations
        {
            var name = Session["Name"].ToString();
            var db = new HospitalEntities();
            var donor = (from d in db.Donors
                         where d.Name == name
                         select d).ToList();
            return View(donor);
            //return View(new Donor(patient));
        }
        //----------------------------------------------------
        public ActionResult DonorList()             //Donor List
        {
            var db = new HospitalEntities();
            var donors = (from d in db.Donors
                          where d.Approval == "Yes"
                          select d).ToList();

            return View(donors);
        }
        //----------------------------------------------------
        [HttpGet]
        public ActionResult Donor_View(int Id)        //Donor details
        {
            var db = new HospitalEntities();
            var donor = (from d in db.Donors
                         where d.Id == Id && d.Approval == "Yes"
                         select d).FirstOrDefault();
            return View(donor);
        }
    }
}