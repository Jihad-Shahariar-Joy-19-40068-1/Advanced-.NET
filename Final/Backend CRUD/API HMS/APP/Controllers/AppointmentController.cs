using BLL.BOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP.Controllers
{
    public class AppointmentController : ApiController
    {
        [Route("api/appointment")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AppointmentService.Get();
            if(data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/appointment/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = AppointmentService.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Appointment found");
        }

        [Route("api/appointment/create")]
        [HttpPost]
        public HttpResponseMessage Create(AppointmentModel a)
        {
            var data = AppointmentService.Create(a);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try again");
        }

        [Route("api/appointment/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(AppointmentModel appointment)
        {
            var data = AppointmentService.Update(appointment);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, appointment);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Such Appointment Found");

        }

        [Route("api/appointment/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = AppointmentService.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Appointment Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Appointment Found");
        }
    }
}
