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
    public class Patient_Epatient_Controller : ApiController
    {

        [Route("api/Epatient/patient")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Patient_Epatient.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/Epatient/patient/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = Patient_Epatient.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Emergency Patient found");
        }

        [Route("api/Epatient/patient/create")]
        [HttpPost]
        public HttpResponseMessage Create(EpatientModel e)
        {
            var data = Patient_Epatient.Create(e);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try again");
        }

        [Route("api/Epatient/patient/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(EpatientModel epatient)
        {
            var data = Patient_Epatient.Update(epatient);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, epatient);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Such Emergency Patient Found");

        }

        [Route("api/Epatient/patient/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = Patient_Epatient.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Emergency Patient Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Emergency Patient Found");
        }
    }
}
