using BLL.DoctorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace APP.Auth
{

    public class ValidUser:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            if (token == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "No token Supplied");
            }

            else
            {
                var res = Doctor_Auth.TokenValidity(token.ToString());
                if (res == false)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Token is invalid or expired");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}