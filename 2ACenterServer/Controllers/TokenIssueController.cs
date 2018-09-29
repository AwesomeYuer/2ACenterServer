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
            var b = JwtTokenHelper
                    .TryIssueToken
                        (
                            "aaa"
                            , appID
                            , JObject.Parse(@"{a:""aaaaaa""}")
                            , "0123456789ABCDEF"
                            , out var plainToken
                            , out var secretToken

                        );

            var result = new JObject();
            result.Add
                    (
                        "SecretToken", secretToken);
            
            return result;
        }
    }
}
