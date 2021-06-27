using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KingResearch.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {               
                await HandleExceptionAsync(httpContext, ex.InnerException);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            

            if (exception.GetType() == typeof(KingResearch.Application.Exception.ValidationException))
            {
                KingResearch.Application.Exception.ValidationException validationException = exception as KingResearch.Application.Exception.ValidationException;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                List<string> errors = new List<string>();
                foreach (var item in validationException.applicationExceptions)
                {
                    errors.Add(item.Message);
                }
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    StatusCode = context.Response.StatusCode,
                    Messages = errors
                }));
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync(new 
                {
                    StatusCode = context.Response.StatusCode,
                    Message = exception.Message
                }.ToString());
            }

        }
    }
}
