using Microsoft.AspNetCore.Builder;
using Serilog;
using WebApi.Modules.Middlewares;

namespace WebApi.Modules
{
    internal static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context => await ExceptionHandlerMiddleware.ExceptionHandler(context, logger));
            });
        }
    }
}
