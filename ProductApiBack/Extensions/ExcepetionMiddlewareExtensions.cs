using Microsoft.AspNetCore.Diagnostics;
using ProductApiBack.Models;
using ProductApiBack.Services;
using System.Net;

namespace ProductApiBack.Extensions
{    
    public class MyCustomExceptionHandler
    {
        private readonly RequestDelegate _next;

        public MyCustomExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILoggerManager logger)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                logger.LogError($"Something went wrong: {contextFeature.Error}");

                await context.Response.WriteAsync(new ErrorDetails
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error"
                }.ToString());
            }

            await _next(context);
        }
    }

    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomExceptionHandler>();
        }
    }
}
