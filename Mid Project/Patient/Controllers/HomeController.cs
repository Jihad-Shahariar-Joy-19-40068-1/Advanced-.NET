using Patient.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HMS.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Registration users)
        {
            HospitalEntities db = new HospitalEntities();
            var st = (from s in db.Registrations
                      where s.Email.Equals(users.Email)
                      && s.Password.Equals(users.Password)
                      select s).SingleOrDefault();
            if (st != null)
            {

                if (st.Type == "P")
                {
                    Session["Type"] = st.Type;
                    Session["logged_user"] = st.Id;
                    Session["Name"] = st.Name;
                    Session["Email"] = st.Email;
                    FormsAuthentication.SetAuthCookie(st.Email, false);
                    TempData["msg"] = "Logged in as a Patient";
                    return RedirectToAction("Index", "Patient"); 
                }
                /*else if (st.Type == "D")
                {
                    Session["Type"] = st.Type;
                    Session["logged_user"] = st.Id;
                    Session["Name"] = st.Name;
                    Session["Email"] = st.Email;
                    FormsAuthentication.SetAuthCookie(st.Email, false);
                    TempData["msg"] = "Logged in as a Doctor";
                    return RedirectToAction("Index", "Doctor");
                }
                else if (st.Type == "Admin")
                {
                    Session["logged_user"] = st.Id;
                    Session["email"] = st.Email;
                    FormsAuthentication.SetAuthCookie(st.Email, false);
                    return RedirectToAction("Dashbord", "Admin");
                }*/

            }
            TempData["msg"] = "User Does Not Exist";
            return View();

        }

        public ActionResult Logout()
        {
            Session.Remove("logged_user");
            Session.Remove("email");
            return RedirectToAction("Index");
            //Session.RemoveAll();
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
    }
}