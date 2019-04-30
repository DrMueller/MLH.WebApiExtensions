using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Mmu.Mlh.WebApiExtensions.Areas.ExceptionHandling.Services;

namespace Mmu.Mlh.WebApiExtensions.Areas.Middlewares
{
    internal class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IExceptionHandler _exceptionHandler;

        public ErrorHandlingMiddleware(RequestDelegate next, IExceptionHandler exceptionHandler)
        {
            _next = next;
            _exceptionHandler = exceptionHandler;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await _exceptionHandler.HandleExceptionAsync(httpContext, exception);
            }
        }
    }
}