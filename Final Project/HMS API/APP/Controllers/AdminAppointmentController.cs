using BLL.AdminServices;
using BLL.BOs;
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
    public class AdminAppointmentController : ApiController
    {
        
        [Route("api/appointment")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AdminAppointmentService.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/appointment/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = AdminAppointmentService.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Appointment found");
        }

        [Route("api/appointment/create")]
        [HttpPost]
        public HttpResponseMessage Create(AdminAppointmentModel a)
        {
            var data = AdminAppointmentService.Create(a);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try again");
        }

        [Route("api/appointment/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(AdminAppointmentModel appointment)
        {
            var data = AdminAppointmentService.Update(appointment);
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
            var data = AdminAppointmentService.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Appointment Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Appointment Found");
        }
    }
}
