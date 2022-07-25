using HMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashbord()
        {

            var id = Int32.Parse(Session["logged_user"].ToString());
            HospitalEntities db = new HospitalEntities();
            var adminn = (from p in db.Registrations
                          where p.Id.Equals(id) && p.Type.Equals("Admin")
                          select p).SingleOrDefault();
            return View(adminn);
        }

        [HttpGet]
        public ActionResult Edit(int Id)        //get value to edit
        {
            var db = new HospitalEntities();
            var admin = (from p in db.Registrations
                         where p.Id == Id && p.Type == "Admin"
                         select p).FirstOrDefault();
            return View(admin);
        }


        [HttpPost]
        public ActionResult Edit(Registration data)        //get value to edit
        {
            HospitalEntities db = new HospitalEntities();
            var admin = (from p in db.Registrations
                         where p.Id.Equals(data.Id) && p.Type.Equals("Admin")
                         select p).FirstOrDefault();
            db.Entry(admin).CurrentValues.SetValues(data);
            db.SaveChanges();
            return RedirectToAction("Dashbord");
        }

        public ActionResult PattientList()
        {
            HospitalEntities db = new HospitalEntities();
            var allpatients = (from p in db.Registrations
                               where p.Type.Equals("P")
                               select p).ToList();
            return View(allpatients);
        }

        [HttpGet]
        public ActionResult SinglePatient(int Id)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var patient = (from p in db.Registrations
                           where p.Id == Id && p.Type == "P"
                           select p).FirstOrDefault();
            return View(patient);
        }
        //single patient edit show

        [HttpGet]
        public ActionResult SinglePatientEdit(int Id)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var patient = (from p in db.Registrations
                           where p.Id == Id && p.Type == "P"
                           select p).FirstOrDefault();
            return View(patient);
        }
        //single patient edit submit

        [HttpPost]
        public ActionResult SinglePatientEdit(Registration data)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var patient = (from p in db.Registrations
                           where p.Id.Equals(data.Id) && p.Type.Equals("P")
                           select p).FirstOrDefault();
            db.Entry(patient).CurrentValues.SetValues(data);
            db.SaveChanges();
            TempData["msg"] = "Patient Edit Successfull";
            return View(patient);
        }
        //get all doctor

        public ActionResult AllDoctorList()
        {
            HospitalEntities db = new HospitalEntities();
            var alldoctor = (from p in db.Registrations
                             where p.Type.Equals("D")
                             select p).ToList();
            return View(alldoctor);
        }

        [HttpGet]
        public ActionResult SingleDoctorEdit(int Id)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from p in db.Registrations
                          where p.Id.Equals(Id) && p.Type.Equals("D")
                          select p).FirstOrDefault();
            return View(doctor);
        }

        [HttpPost]
        public ActionResult SingleDoctorEdit(Registration data)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from p in db.Registrations
                          where p.Id.Equals(data.Id) && p.Type.Equals("D")
                          select p).FirstOrDefault();
            db.Entry(doctor).CurrentValues.SetValues(data);
            db.SaveChanges();
            TempData["msg"] = "Doctor Edit Successfull";

            return View(doctor);
        }

        //Add doctor
        [HttpGet]
        public ActionResult Addoctor()     //view one from list
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addoctor(Registration data)     //view one from list
        {
            if (ModelState.IsValid)
            {
                HospitalEntities db = new HospitalEntities();
                db.Registrations.Add(data);
                db.SaveChanges();

                return RedirectToAction("AllDoctorList");
            }
            return View();
        }

        //Notice View
        [HttpGet]
        public ActionResult Notice()
        {
            HospitalEntities db = new HospitalEntities();
            var notice = (from p in db.Notices select p).ToList();
            return View(notice);

        }


        [HttpGet]
        public ActionResult AddNotice()
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from p in db.Notices select p).ToList();
            return View(doctor);

        }
        [HttpPost]
        public ActionResult AddNotice(Notice data)
        {

            HospitalEntities db = new HospitalEntities();
            db.Notices.Add(data);
            db.SaveChanges();
            TempData["msg"] = "Notice Upload Successful";

            return RedirectToAction("Notice");
        }
        public ActionResult Delete(int Id)  //Notice Delete
        {
            HospitalEntities db = new HospitalEntities();
            var notice = (from p in db.Notices
                          where p.Id.Equals(Id)
                          select p).FirstOrDefault();
            db.Notices.Remove(notice);
            db.SaveChanges();
            return RedirectToAction("Notice");
        }

        [HttpGet]
        public ActionResult NoticeEdit(int Id)
        {
            HospitalEntities db = new HospitalEntities();
            var notice = (from p in db.Notices
                          where p.Id.Equals(Id)
                          select p).FirstOrDefault();
            return View(notice);
        }
        [HttpPost]
        public ActionResult NoticeEdit(Notice data)
        {
            HospitalEntities db = new HospitalEntities();
            var notice = (from p in db.Notices
                          where p.Id.Equals(data.Id)
                          select p).FirstOrDefault();
            db.Entry(notice).CurrentValues.SetValues(data);
            db.SaveChanges();
            TempData["msg"] = "Notice Edit Successfull";
            return RedirectToAction("Notice");
        }


        [HttpGet]
        public ActionResult AddSalary(int Id)
        {
            HospitalEntities db = new HospitalEntities();
            var salary = (from p in db.Registrations
                          where p.Id.Equals(Id)
                          select p).FirstOrDefault();
            return View(salary);
        }

        [HttpPost]
        public ActionResult AddSalary(Registration data)
        {
            HospitalEntities db = new HospitalEntities();
            var salary = (from p in db.Registrations
                          where p.Id.Equals(data.Id)
                          select p).FirstOrDefault();
            db.Entry(salary).CurrentValues.SetValues(data);
            db.SaveChanges();
            return RedirectToAction("AllDoctorList");
        }
        public ActionResult DoctorDelete(int Id)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from p in db.Registrations
                          where p.Id.Equals(Id)
                          select p).FirstOrDefault();
            db.Registrations.Remove(doctor);
            db.SaveChanges();

            return RedirectToAction("AllDoctorList");
        }

        public ActionResult PatientDelete(int Id)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var patient = (from p in db.Registrations
                           where p.Id.Equals(Id)
                           select p).FirstOrDefault();
            db.Registrations.Remove(patient);
            db.SaveChanges();

            return RedirectToAction("PattientList");
        }

        [HttpGet]
        public ActionResult AllAppointment()
        {
            HospitalEntities db = new HospitalEntities();
            var appointment = (from p in db.Appointments
                               select p).ToList();
            return View(appointment);
        }
        [HttpGet]
        public ActionResult AppointmentEdit(int Id)
        {
            HospitalEntities db = new HospitalEntities();
            var appointment = (from p in db.Appointments
                               where p.Id.Equals(Id)
                               select p).FirstOrDefault();
            return View(appointment);
        }
        [HttpPost]
        public ActionResult AppointmentEdit(Appointment data)
        {
            HospitalEntities db = new HospitalEntities();
            var appointment = (from p in db.Appointments
                               where p.Id.Equals(data.Id)
                               select p).FirstOrDefault();
            db.Entry(appointment).CurrentValues.SetValues(data);
            db.SaveChanges();

            return RedirectToAction("AllAppointment");
        }
        public ActionResult AppointmentDelete(int Id)
        {
            HospitalEntities db = new HospitalEntities();

            var appointment = (from p in db.Appointments
                               where p.Id.Equals(Id)
                               select p).FirstOrDefault();
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("AllAppointment");
        }


       //View Emergency Patient
        public ActionResult EmergencyPatient()
        {
            HospitalEntities db = new HospitalEntities();

            var emergency = (from p in db.Epatients
                             select p).ToList();
            return View(emergency);
        }

        public ActionResult EmergencyPatientDelete(int Id)
        {
            HospitalEntities db = new HospitalEntities();
            var emergency = (from p in db.Epatients
                             where p.Id.Equals(Id)
                             select p).FirstOrDefault();
            db.Epatients.Remove(emergency);
            db.SaveChanges();
            return RedirectToAction("EmergencyPatient");

        }

        public ActionResult DoctorProblems()
        {
            var db = new HospitalEntities();
            var problems = db.ProblemLists.ToList();
            return View(problems);
        }
        
        public ActionResult DoctorProblemDelete(int Id)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var problem = (from p in db.ProblemLists
                           where p.Id.Equals(Id)
                           select p).FirstOrDefault();
            db.ProblemLists.Remove(problem);
            db.SaveChanges();

            return RedirectToAction("DoctorProblems");
        }
    }
}