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
    public class Patient_loginController : ApiController
    {
        [Route("api/login/patient")]
        [HttpPost]
        public HttpResponseMessage Login(LoginModel obj)
        {
            var data = Patient_Auth.Authenticate(obj.Email, obj.Password);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [Route("api/logout/patient")]
        public HttpResponseMessage Logout(TokenModel obj)
        {
            var data = Patient_Auth.Logout(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
