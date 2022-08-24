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
    public class Doctor_Epatient_Controller : ApiController
    {
        [Route("api/Epatient/doctor")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Doctor_Epatient.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }

        [Route("api/Epatient/treatment/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(EpatientModel epatient)
        {
            var data = Doctor_Epatient.Update(epatient);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, epatient);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Doctor Found");
        }
    }
}
