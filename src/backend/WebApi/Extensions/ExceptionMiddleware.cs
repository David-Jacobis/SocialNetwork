using Business.Interfaces;
using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Resources;
using Serilog;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ErrorResource _resource;

        public ExceptionMiddleware(RequestDelegate next,  ErrorResource resource)
        {
            _next = next;
            //_logger = logger;
            _resource = resource;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = (int)HttpStatusCode.BadRequest;
            string msg = exception?.Message;

            if (exception is UnauthorizedAccessException) { statusCode = (int)HttpStatusCode.Unauthorized; msg = _resource.Unauthorized; }
            if (exception is FormatException) { statusCode = (int)HttpStatusCode.UnsupportedMediaType; msg = _resource.WrongFormat; }

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                success = false,
                data = msg
            }));
        }

        private string getEvent(Exception ex)
        {
            var _event = string.Empty;
            if(!string.IsNullOrEmpty(ex.StackTrace))
            {
                StackTrace trace = new StackTrace(ex, true);
                StackFrame stackFrame = trace.GetFrame(0);
                _event = stackFrame.GetMethod().Name;                
            }
            return _event;
        }
    }
}
