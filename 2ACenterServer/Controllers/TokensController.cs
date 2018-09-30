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
    public class TokensController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<JToken> Issue
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
                            //, JObject.Parse(@"{a:""aaaaaa"",a1:{F1:""aaaaaa""}}")
                            , new Claim[] 
                            {
                                new Claim
                                    (
                                        "aaaa"
                                        , @"[{ R:""manger"",D:""HR"" },{ R:""manger1"",D:""HR1"" }]"
                                    )
                            }

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
