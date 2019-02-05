using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Mmu.Mlh.ApplicationExtensions.Areas.Logging.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WebApiExtensions.Areas.ExceptionHandling.Services;
using Newtonsoft.Json;

namespace Mmu.Mlh.WebApiExtensions.Areas.Middlewares
{
    internal class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                var exceptionHandler = ServiceLocatorSingleton.Instance.GetService<IExceptionHandler>();
                await exceptionHandler.HandleExceptionAsync(httpContext, exception);
            }
        }
    }
}