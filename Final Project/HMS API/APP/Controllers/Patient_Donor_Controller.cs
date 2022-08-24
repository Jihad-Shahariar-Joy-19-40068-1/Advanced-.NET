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
    /*[ValidUser]*/
    public class Patient_Donor_Controller : ApiController
    {
        [Route("api/donor/patient/")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Patient_Donor.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/donor/patient/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = Patient_Donor.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Donor found");
        }

        [Route("api/donor/patient/create")]
        [HttpPost]
        public HttpResponseMessage Create(DonorModel d)
        {
            var data = Patient_Donor.Create(d);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try again");
        }

        [Route("api/donor/patient/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(DonorModel donor)
        {
            var data = Patient_Donor.Update(donor);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, donor);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Donor Found");

        }

        [Route("api/donor/patient/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = Patient_Donor.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Donor Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Donor Found");
        }
    }
}
