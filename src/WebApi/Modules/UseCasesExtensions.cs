using Application.UseCases.Users.PostUser;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IPostUserUseCase, PostUserUseCase>();
            return services;
        }
    }
}