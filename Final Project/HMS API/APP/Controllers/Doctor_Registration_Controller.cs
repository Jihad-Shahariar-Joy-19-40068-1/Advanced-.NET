using APP.Auth;
using BLL.BOs;
using BLL.DoctorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APP.Controllers
{
    [EnableCors("*", "*", "*")]
    [ValidUser]
    public class Doctor_Registration_Controller : ApiController
    {
        [Route("api/doctorlist")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Doctor_Registration.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/create/doctor")]
        [HttpPost]
        public HttpResponseMessage Create(RegistrationModel st)
        {
            var data =Doctor_Registration.Create(st);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try Again");
        }

        [Route("api/update/doctor/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(RegistrationModel doctor)
        {
            var data = Doctor_Registration.Update(doctor);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, doctor);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Doctor Found");
        }
        [Route("api/delete/doctor/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = Doctor_Registration.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Doctor Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Doctor Found");
        }

        [Route("api/doctor/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = Doctor_Registration.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Doctor Found");
        }
    }
}
