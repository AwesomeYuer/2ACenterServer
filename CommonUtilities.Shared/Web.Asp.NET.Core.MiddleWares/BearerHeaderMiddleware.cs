using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;

namespace Microshaoft.Web
{
    public class BearerJwtAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public BearerJwtAuthorizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}