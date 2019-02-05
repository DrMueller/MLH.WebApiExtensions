using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Mmu.Mlh.ApplicationExtensions.Areas.Logging.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Exceptions;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WebApiExtensions.Areas.Middlewares;
using Newtonsoft.Json;

namespace Mmu.Mlh.WebApiExtensions.Areas.ExceptionHandling.Services.Implementation
{
    internal class ExceptionHandler : IExceptionHandler
    {
        private readonly IExceptionCallbackService _exceptionCallbackService;

        public ExceptionHandler(IExceptionCallbackService exceptionCallbackService)
        {
            _exceptionCallbackService = exceptionCallbackService;
        }

        public async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            exception = exception.GetMostInnerException();
            _exceptionCallbackService.InvokeExceptionCallback(exception);

            LogException(exception);

            await WriteResponseAsync(httpContext, exception);
        }

        private static void LogException(Exception exception)
        {
            var loggingService = ServiceLocatorSingleton.Instance.GetService<ILoggingService>();
            loggingService.LogException(exception);
        }

        private static async Task WriteResponseAsync(HttpContext httpContext, Exception exception)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var serverException = ServerException.CreateFromException(exception);
            var serializedServerError = JsonConvert.SerializeObject(serverException);

            await response.WriteAsync(serializedServerError);
        }
    }
}