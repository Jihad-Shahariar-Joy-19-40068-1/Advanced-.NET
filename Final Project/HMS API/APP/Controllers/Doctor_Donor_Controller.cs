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
    public class Doctor_Donor_Controller : ApiController
    {
        [Route("api/donor/doctor")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Doctor_Donor.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }

        [Route("api/donor/approve/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(DonorModel student)
        {
            var data = Doctor_Donor.Update(student);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Donor Found");
        }
    }
}
