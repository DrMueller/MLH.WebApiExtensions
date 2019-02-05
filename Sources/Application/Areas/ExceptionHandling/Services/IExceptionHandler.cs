using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Mmu.Mlh.WebApiExtensions.Areas.ExceptionHandling.Services
{
    internal interface IExceptionHandler
    {
        Task HandleExceptionAsync(HttpContext htttpContext, Exception exception);
    }
}
