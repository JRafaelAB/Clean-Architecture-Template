using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Modules.Swagger
{
    internal sealed class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this._provider = provider;
        }
        
        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in this._provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateApiVersionDoc(description));
            }
        }

        private static OpenApiInfo CreateApiVersionDoc(ApiVersionDescription description)
        {
            return new OpenApiInfo
            {
                Version = description.ApiVersion.ToString(),
                Title = "Clean Architecture Template",
                Description = "Clean Architecture Template." + (description.IsDeprecated?" Essa versão da api foi descontinuada.":string.Empty),
                Contact = new OpenApiContact
                {
                    Name = "Jonas Borges",
                    Email = "[jonas.borges@dtidigital.com.br]"
                }
            };
        }
    }
}
