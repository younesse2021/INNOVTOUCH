using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace Shared.Models.COMMON
{
    public static class ApiResponse
    {
        public const string Message_Ok = "Ok";
        public const string Message_InvalidInput = "Invalid input";
        public const string Message_Error = "An error occured";
        public const string Message_NotFound = "Not found";
       

        public static ObjectResult CreateResponse(
            HttpStatusCode statusCode,
            string message)
        {
            var problem = new Response<string>()
            {
                Message = message,
            };

            return new ObjectResult(problem) { StatusCode = (int)statusCode };
        }

        public static ObjectResult CreateResponse<T>(
            HttpStatusCode statusCode,
            T data,
            string message = "")
        {
            var problem = new Response<T>()
            {
                Message = message,
                Data = data,
            };

            return new ObjectResult(problem) { StatusCode = (int)statusCode };
        }
    }
}