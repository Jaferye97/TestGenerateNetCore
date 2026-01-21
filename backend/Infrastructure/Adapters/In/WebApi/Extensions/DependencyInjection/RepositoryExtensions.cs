using Application.Ports.Persistence;
using RepositoryEntityFrameworkSqlServer.Persistence.EntityFramework;

namespace WebApi.Extensions.DependencyInjection;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // 
        services.AddScoped<ISupplierRepositoryPort, SupplierRepository>();
        //services.AddScoped<ISupplierAttributeRepository, SupplierAttributeRepository>();

        return services;
    }
}
