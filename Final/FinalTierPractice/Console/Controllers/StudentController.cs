using BLL.BOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Console.Controllers
{
    public class StudentController : ApiController
    {
        [Route("api/student")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = StudentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/student/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = StudentService.GetOnly(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        /*[Route("api/student/single/{id}")]
        [HttpGet]
        public HttpRequestMessage Get(int id)
        {
            var data = StudentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }*/

        [Route("api/student/create")]
        [HttpPost]
        public HttpResponseMessage Create(StudentModel st)
        {
            var data = StudentService.Create(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/student/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(StudentModel student)
        {
            var data = StudentService.Update(student);
            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        [Route("api/student/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = StudentService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }
    }
}
