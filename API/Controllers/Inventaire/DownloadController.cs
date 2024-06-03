using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class DownloadController : BaseController
    {
        [HttpGet("api/download/{ean}")]
        public IActionResult Download(string ean)
        {
            using (var client = new WebClient())
            {
                var FileName = ean + ".png";
                var FileBytes = client.DownloadData(@$"http://192.168.99.96:8082/eretail/{FileName}");               
                return File(FileBytes, "image/jpeg");
            }
        }
    }
}
