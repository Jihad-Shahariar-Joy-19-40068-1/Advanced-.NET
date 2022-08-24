using APP.Auth;
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
    [ValidUser]
    public class Patient_Notice_Controller : ApiController
    {
        [Route("api/notic/epatient")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Patient_Notice.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
    }
}
