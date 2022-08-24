using APP.Auth;
using BLL.BOs;
using BLL.PatientServices;
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
    public class Patient_Registration_Controller : ApiController
    {
        [Route("api/patientlist")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Patient_Registration.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/patient/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = Patient_Registration.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Patient Found");
        }

        [Route("api/create/patient")]
        [HttpPost]
        public HttpResponseMessage Create(RegistrationModel pt)
        {
            var data = Patient_Registration.Create(pt);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try Again");
        }

        [Route("api/update/patient/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(RegistrationModel patient)
        {
            var data = Patient_Registration.Update(patient);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Patient Found");
        }

        [Route("api/delete/patient/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = Patient_Registration.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Patient Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Patient Found");
        }
    }
}
