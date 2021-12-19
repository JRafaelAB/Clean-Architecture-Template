using Domain.DataObjects.Entities.Factories;
using Domain.DataObjects.Entities.User;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Modules
{
    public static class EntityFactoryExtensions
    {
        public static IServiceCollection AddEntityFactories(this IServiceCollection services)
        {
            services.AddScoped<IUserEntityFactory, UserEntityFactory>();
            return services;
        }
    }
}
