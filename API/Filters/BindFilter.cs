using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
using System;

namespace API.Filters
{

    [AttributeUsage(validOn: AttributeTargets.All)]
    public class BindFilter : Attribute, IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.Request.Headers.TryGetValue("user_name", out var USERNAME);
            if (StringValues.IsNullOrEmpty(USERNAME))
            {
                await next();
            }

            context.HttpContext.Items["user_name"] = USERNAME;

            await next();
        }
    }
}