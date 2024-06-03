using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Models;
using Shared.Models.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string HEADERAPIKEYNAME = "APPBUILDVERSION";
        private const string APIKEYNAME = "BUILDVERSION";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            //if (!context.HttpContext.Request.Headers.TryGetValue(HEADERAPIKEYNAME, out var extractedApiKey))
            //{
            //    context.Result = ApiResponse.CreateResponse(HttpStatusCode.Forbidden, message: "La clé API n'est pas valide");
            //    return;
            //}

            //var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            //var apiKey = appSettings.GetValue<string>(APIKEYNAME);

            //if (!apiKey.Equals(extractedApiKey))
            //{
            //    context.Result = ApiResponse.CreateResponse(HttpStatusCode.Forbidden, message: "La clé API n'est pas valide");
            //    return;
            //}

            await next();
        }
    }
}