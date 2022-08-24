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
    public class AdminEpatientController : ApiController
    {
        [Route("api/epatient")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AdminEpatientService.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/epatient/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = AdminEpatientService.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Emergency patient  found");
        }
        [Route("api/epatient/create")]
        [HttpPost]
        public HttpResponseMessage Create(AdminEpatientModel a)
        {
            var data = AdminEpatientService.Create(a);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try again");
        }

        [Route("api/epatient/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(AdminEpatientModel notice)
        {
            var data = AdminEpatientService.Update(notice);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Emergency patient  Found");

        }

        [Route("api/epatient/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = AdminEpatientService.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Emergency patient Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Notice Found");
        }

    }
}
