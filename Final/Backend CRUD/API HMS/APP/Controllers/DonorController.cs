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
    public class DonorController : ApiController
    {
        [Route("api/donor")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = DonorService.Get();
            if(data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/donor/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = DonorService.GetOnly(id);
            if(data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Donor found");
        }

        [Route("api/donor/create")]
        [HttpPost]
        public HttpResponseMessage Create(DonorModel d)
        {
            var data = DonorService.Create(d);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try again");
        }

        [Route("api/donor/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(DonorModel donor)
        {
            var data = DonorService.Update(donor);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, donor);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Donor Found");

        }

        [Route("api/donor/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = DonorService.Delete(id);
            if(data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Donor Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Donor Found");
        }
    }
}
