using Microsoft.OpenApi.Models;

namespace WebApi.Extensions.DependencyInjection;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Suppliers API",
                Version = "v1",
                Description = "API de gestión de proveedores y servicios"
            });
        });

        return services;
    }
}
