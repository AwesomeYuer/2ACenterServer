using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace _2ACenterServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .UseUrls("http://+:5000")

             //// 自宿主专用
            //.UseHttpSys(options =>
            //{
            //    options.Authentication.Schemes =
            //        AuthenticationSchemes.NTLM
            //        |
            //        AuthenticationSchemes.Negotiate

            //        ;
            //    options.Authentication.AllowAnonymous = false;
            //})
            ;

    }
}
