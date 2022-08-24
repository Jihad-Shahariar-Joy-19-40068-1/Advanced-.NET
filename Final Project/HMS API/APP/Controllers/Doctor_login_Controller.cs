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
    [EnableCors( "*","*","*")]
    public class Doctor_login_Controller : ApiController
    {
        [Route("api/login/doctor")]
        [HttpPost]
        public HttpResponseMessage Login(LoginModel obj)
        {
            var data = Doctor_Auth.Authenticate(obj.Email, obj.Password);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [Route("api/logout/doctor")]
        public HttpResponseMessage Logout(TokenModel obj)
        {
            var data = Doctor_Auth.Logout(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
