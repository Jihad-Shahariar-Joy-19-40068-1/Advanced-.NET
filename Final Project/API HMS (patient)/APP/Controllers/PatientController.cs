using APP.Auth;
using BLL.BOs;
using BLL.Services;
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
    public class PatientController : ApiController
    {
        [ValidUser]
        [Route("api/patient")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            
            var data = PatientService.Get();
            if(data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/patient/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = PatientService.GetOnly(id);
            if(data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Patient Found");
        }

        [Route("api/patient/create")]
        [HttpPost]
        public HttpResponseMessage Create(PatientModel pt)
        {
            var data = PatientService.Create(pt);
            if(data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try Again");
        }

        [Route("api/patient/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(PatientModel patient)
        {
            var data = PatientService.Update(patient);
            if(data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Patient Found");
        }

        [Route("api/patient/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = PatientService.Delete(id);
            if(data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Patient Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Patient Found");
        }
    }
}
