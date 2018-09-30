using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microshaoft;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Internal;

namespace Microshaoft.Web
{
    public class BearerTokenAuthorizeFilter
                    :
                        //AuthorizeAttribute
                        Attribute
                        , IActionFilter
    {
        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    var s = "Attribute_OnActionExecuting";

        //    //context.HttpContext.Request.Headers
        //}
        //public void OnActionExecuted(ActionExecutedContext context)
        //{
        //    //todo
        //    context.Result = new ContentResult()
        //    {
        //        Content = "Resource unavailable - header should not be set"
        //    };
        //}
        private string _requestTokenName;
        public BearerTokenAuthorizeFilter
                    (
                        string requestTokenName = "Microshaoft-Authorization-Bearer"
                    )
        {
            _requestTokenName = requestTokenName;



        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            var ok = request.Headers.TryGetValue(_requestTokenName, out var token);
            if (ok)
            {
                ok = JwtTokenHelper
                        .TryValidateToken
                            (
                                "0123456789ABCDEF"
                                , token
                                , out var validatedPlainToken
                                , out var claimsPrincipal
                            );
                if (ok)
                {
                    var userName1 = context.HttpContext.User.Identity.Name;
                    var userName2 = claimsPrincipal.Identity.Name;
                    ok = (string.Compare(userName1, userName2, true) == 0);
                }
                if (ok)
                {
                    context.HttpContext.User = claimsPrincipal;
                }


                if (!ok)
                {
                    context.Result = new ForbidResult();
                    return;
                }

            }
           
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();


        }


    }
}
