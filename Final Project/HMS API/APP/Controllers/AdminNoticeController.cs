using BLL.AdminServices;
using BLL.BOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP.Controllers
{
    public class AdminNoticeController : ApiController
    {
        [Route("api/notice")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AdminNoticeService.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/notice/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = AdminNoticeService.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Notice found");
        }
        [Route("api/notice/create")]
        [HttpPost]
        public HttpResponseMessage Create(AdminNoticeModel a)
        {
            var data = AdminNoticeService.Create(a);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try again");
        }

        [Route("api/notice/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(AdminNoticeModel notice)
        {
            var data = AdminNoticeService.Update(notice);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Notice Found");

        }

        [Route("api/notice/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = AdminNoticeService.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Notice Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Notice Found");
        }
    }
}
