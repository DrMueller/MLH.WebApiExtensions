using System;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.WebApiExtensions.Areas.ExceptionHandling.Services
{
    internal interface IExceptionCallbackService
    {
        void InitializeCallback(Maybe<Action<Exception>> maybeExceptionCallback);

        void InvokeExceptionCallback(Exception exception);
    }
}