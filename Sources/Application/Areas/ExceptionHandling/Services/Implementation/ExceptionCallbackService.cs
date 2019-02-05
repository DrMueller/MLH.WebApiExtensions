using System;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.WebApiExtensions.Areas.ExceptionHandling.Services.Implementation
{
    internal class ExceptionCallbackService : IExceptionCallbackService
    {
        private Maybe<Action<Exception>> _maybeExceptionCallback;

        public void InitializeCallback(Maybe<Action<Exception>> maybeExceptionCallback)
        {
            _maybeExceptionCallback = maybeExceptionCallback;
        }

        public void InvokeExceptionCallback(Exception exception)
        {
            _maybeExceptionCallback.Evaluate(cb => cb(exception));
        }
    }
}