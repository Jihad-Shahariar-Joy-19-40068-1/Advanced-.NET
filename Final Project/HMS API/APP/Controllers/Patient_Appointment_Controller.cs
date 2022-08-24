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
    public class Patient_Appointment_Controller : ApiController
    {
        [Route("api/appointment/patient")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Patient_Appointment.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/appointment/patient/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = Patient_Appointment.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Appointment found");
        }

        [Route("api/appointment/patient/create")]
        [HttpPost]
        public HttpResponseMessage Create(AppointmentModel a)
        {
            var data = Patient_Appointment.Create(a);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try again");
        }

        [Route("api/appointment/patient/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(AppointmentModel appointment)
        {
            var data = Patient_Appointment.Update(appointment);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, appointment);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Such Appointment Found");

        }

        [Route("api/appointment/patient/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = Patient_Appointment.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Appointment Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Appointment Found");
        }
    }
}
