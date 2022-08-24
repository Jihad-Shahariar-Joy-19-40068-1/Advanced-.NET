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
    /*[ValidUser]*/
    public class Doctor_Appointment_Controller : ApiController
    {
        [Route("api/appointment/doctor")]
        [HttpGet]

        public HttpResponseMessage Get()
        {


            /*            var token = Request.Headers.Authorization;
                        if (token == null)
                        {
                            return Request.CreateResponse(HttpStatusCode.Unauthorized,"Not token Supplied!");
                        }*/
            var data = Doctor_Appointment.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }


        [ValidUser]
        [Route("api/appointment/prescription/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(AppointmentModel ap)
        {
            var data = Doctor_Appointment.Update(ap);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Appointment Found");
        }
    }
}
