
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shared.Models;
using Shared.Models.IN;
using System;
using System.Threading.Tasks;

namespace API.Controllers.Helper
{
    [Route("api/mobile")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MobileController> _logger;

        public MobileController(IConfiguration configuration, ILogger<MobileController> logger
                                                            )
        {
            _configuration = configuration;
            _logger = logger;
            _logger.LogInformation("MobileController(...)");
        }

        [HttpGet("checkversionvalide/{version}")]
        public async Task<IActionResult> CheckVersion(double version = -1)
        {
            _logger.LogInformation($"Version to verify {version}");

            double versionActuel = 0;
            versionActuel = Convert.ToDouble(_configuration.GetValue<string>("InnovTouch:VersionApk"));
            _logger.LogInformation($"Version actuel {versionActuel}");
            var response = new Response<bool>(versionActuel <= version);
            return Ok(response);
        }
    }
}
