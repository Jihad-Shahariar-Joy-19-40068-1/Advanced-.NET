using APP.Auth;
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
    public class Doctor_Notice_Controller : ApiController
    {
        [Route("api/DoctorNotice")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Doctor_Notice.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
    }
}
