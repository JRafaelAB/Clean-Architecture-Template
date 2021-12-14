using Domain.Constants;
using Domain.Repositories;
using Domain.UnitOfWork;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Modules
{
    internal static class SQLExtensions
    {
        public static IServiceCollection AddSQLServer(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>(AppSettingsVariables.SqlClockConnectionString) ?? string.Empty;

            services.AddDbContext<ClockContext>(
                options =>
                {
                    options.UseSqlServer(connectionString, option => option.MigrationsAssembly("Infrastructure"));
                    options.EnableSensitiveDataLogging();
                });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}