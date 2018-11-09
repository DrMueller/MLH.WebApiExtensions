using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.WebApiExtensions.Areas.Middlewares
{
    public class ServerError
    {
        public string Message { get; }
        public string StackTrace { get; }
        public string TypeName { get; }

        public ServerError(string message, string typeName, string stackTrace)
        {
            Guard.StringNotNullOrEmpty(() => message);
            Guard.StringNotNullOrEmpty(() => typeName);
            Guard.StringNotNullOrEmpty(() => stackTrace);

            Message = message;
            TypeName = typeName;
            StackTrace = stackTrace;
        }

        public static ServerError CreateFromException(Exception ex)
        {
            return new ServerError(ex.Message, ex.GetType().Name, ex.StackTrace);
        }
    }
}