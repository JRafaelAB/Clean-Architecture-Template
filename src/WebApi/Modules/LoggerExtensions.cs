using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace WebApi.Modules
{
    internal static class LoggerExtensions
    {
        public static IServiceCollection AddLogger(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<ILogger>(new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger());

            return services;
        }
    }
}
