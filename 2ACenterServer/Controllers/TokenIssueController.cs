namespace Microshaoft.Web.Samples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using Microshaoft;
    using Microshaoft.WebApi.ModelBinders;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication.JwtBearer;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenIssueController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<JToken> Get
                        (
                            [ModelBinder(typeof(JTokenModelBinder))]
                                JToken json
                        )
        {
            var appID = json["AppID"].Value<string>();
            var userID = json["UserID"].Value<string>();

            var claims = new Claim[]
                        {
                            new Claim(ClaimTypes.Name, userID)
                            , new Claim
                                    (
                                        ClaimTypes.Expiration
                                        , DateTime.Now.AddSeconds(1000).ToString()
                                    )
                             , new Claim("Role", "pjm")
                        };
            //用户标识
            //JsonWe
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
            identity.AddClaims(claims);

            //var token = JW
            //return new JsonResult(token);

            return null;
        }
    }
}
