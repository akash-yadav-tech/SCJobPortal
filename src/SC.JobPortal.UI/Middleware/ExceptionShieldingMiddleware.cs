using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SC.JobPortal.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SC.JobPortal.UI.Middleware
{
    public class ExceptionShieldingMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ExceptionShieldingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                Guid errorId = Guid.NewGuid();

                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = $"Internal Server Error. Please contact Admin. ErrorId: {errorId}"
                }.ToString());
            }
        }
    }

    public static class ExceptionShieldingMiddlewareExtension
    {
        public static void UseExceptionShieldingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionShieldingMiddleware>();
        }
    }
}
