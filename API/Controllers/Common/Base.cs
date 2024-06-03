using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shared.Models.COMMON;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class Base
    {
        public static IConfigurationRoot Configuration;

        public static ENV Init()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var _env = new ENV()
            {
                Server_ = Configuration[$"ENV:Server_"],
                Username_ = Configuration[$"ENV:Username_"],
                Password_ = Configuration[$"ENV:Password_"],
                Server_Demarque = Configuration[$"DEMARQUE:Server_Demarque"],
                Username_Demarque = Configuration[$"DEMARQUE:Username_Demarque"],
                Password_Demarque = Configuration[$"DEMARQUE:Password_Demarque"],
                BaseUrlAPI = Configuration[$"ENV:BaseUrlAPI"],
                BaseUrlImage = Configuration[$"ENV:BaseUrlImage"],
                BaseUrlZip = Configuration[$"ENV:BaseUrlZip"],
                Host_SSH = Configuration[$"ENV:Host_SSH"],
                Username_SSH = Configuration[$"ENV:Username_SSH"],
                Password_SSH = Configuration[$"ENV:Password_SSH"]                
            };
            return _env;
        }
    }
}
