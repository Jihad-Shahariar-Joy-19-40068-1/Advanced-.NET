﻿using BLL.BOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginModel obj)
        {
            var data = AuthService.Authenticate(obj.Email, obj.Password);
            if(data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No User Found");
        }
        [Route("api/logout")]
        public HttpResponseMessage Logout(TokenModel obj)
        {
            var data = AuthService.Logout(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
