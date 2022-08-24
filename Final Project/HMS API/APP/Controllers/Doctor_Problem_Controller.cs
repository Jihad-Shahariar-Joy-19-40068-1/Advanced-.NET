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
    
    public class Doctor_Problem_Controller : ApiController
    {
        [Route("api/problemlist")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Doctor_ProblemList.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/problem/create")]
        [HttpPost]
        public HttpResponseMessage Create(ProblemListModel st)
        {
            var data = Doctor_ProblemList.Create(st);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try Again");
        }
        [ValidUser]
        [Route("api/problem/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(ProblemListModel pb)
        {
            var data = Doctor_ProblemList.Update(pb);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Doctor Found");
        }
        [ValidUser]
        [Route("api/problem/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = Doctor_ProblemList.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Problem Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Problem Found");
        }
        [Route("api/problem/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = Doctor_ProblemList.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Problem Found");
        }
    }
}
