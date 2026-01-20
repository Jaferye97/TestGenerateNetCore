// using Application.Ports.RepositoryEntityFrameworkSqlServer;
using RepositoryEntityFrameworkSqlServer.Repositories.Implementations;
using RepositoryEntityFrameworkSqlServer.Repositories;

namespace WebApi.Extensions.DependencyInjection;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Examples
        //services.AddScoped<ISupplierAttributeRepositoryPort, SupplierAttributeRepository>();
        //services.AddScoped<ISupplierAttributeRepository, SupplierAttributeRepository>();

        return services;
    }
}
