using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EventManagement.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeApi: AuthorizationFilterAttribute
    {


        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (filterContext== null)
            {
                throw new Exception("actionContext is null");
            }
            if (!IsAuthorized(filterContext))
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }

        private void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Not allowed to access...bla bla");
        }

        protected bool IsAuthorized(HttpActionContext filterContext)
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

    }
}