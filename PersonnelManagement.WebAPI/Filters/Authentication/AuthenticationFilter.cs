using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelManagement.WebAPI.Filters.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var personnel = (Personnel)context.HttpContext.Items["User"];
            if (personnel==null)
            {
                context.Result = new JsonResult(new { message = "UnAuthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
