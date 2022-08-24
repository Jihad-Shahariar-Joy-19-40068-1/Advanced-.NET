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
    public class EpatientController : ApiController
    {
        [Route("api/Epatient")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = EpatientService.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/Epatient/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = EpatientService.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Emergency Patient found");
        }

        [Route("api/Epatient/create")]
        [HttpPost]
        public HttpResponseMessage Create(EpatientModel e)
        {
            var data = EpatientService.Create(e);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try again");
        }

        [Route("api/Epatient/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(EpatientModel epatient)
        {
            var data = EpatientService.Update(epatient);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, epatient);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Such Emergency Patient Found");

        }

        [Route("api/Epatient/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = EpatientService.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Emergency Patient Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Emergency Patient Found");
        }
    }
}
