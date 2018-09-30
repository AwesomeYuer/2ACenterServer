using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microshaoft.Web
{
    public class MyActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //todo
            context.Result = new ContentResult()
            {
                Content = "Resource unavailable - header should not be set"
            };
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var s = "Attribute_OnActionExecuting";

            //context.HttpContext.Request.Headers
        }
    }
}
