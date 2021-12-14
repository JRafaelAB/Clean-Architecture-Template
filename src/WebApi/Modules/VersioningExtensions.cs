using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Modules
{
    internal static class VersioningExtensions
    {
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services
                .AddApiVersioning(p =>
                {
                    p.DefaultApiVersion = new ApiVersion(1, 0);
                    p.ReportApiVersions = true;
                    p.AssumeDefaultVersionWhenUnspecified = true;
                });

            services
                .AddVersionedApiExplorer(p =>
                {
                    p.GroupNameFormat = "'v'VVV";
                    p.SubstituteApiVersionInUrl = true;
                });

            return services;
        }
        
    }
}
