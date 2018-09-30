namespace Microshaoft.Web.Samples
{
    using Microshaoft;
    using Microshaoft.WebApi.ModelBinders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using System.Security.Claims;

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
            var userName = HttpContext.User.Identity.Name;
            var b = JwtTokenHelper
                            .TryIssueToken
                                (
                                    "aaa"
                                    , appID
                                    , userName
                                    //, JObject.Parse(@"{a:""aaaaaa"",a1:{F1:""aaaaaa""}}")
                                    , new Claim[] 
                                    {
                                        new Claim
                                            (
                                                "Extension"
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
                        "SecretToken"
                        , secretToken
                     );
            return result;
        }
    }
}
