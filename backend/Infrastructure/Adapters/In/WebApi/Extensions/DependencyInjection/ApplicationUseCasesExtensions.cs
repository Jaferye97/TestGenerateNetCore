using Application.UseCases.Supplier;
using Application.UseCases.Supplier.Implementations;

namespace WebApi.Extensions.DependencyInjection;

public static class ApplicationUseCasesExtensions
{
	public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
    {
        //Example
        services.AddScoped<IGetSupplierByIdUseCase, GetSupplierByIdUseCase>();
        services.AddScoped<IAddSupplierUseCase, AddSupplierUseCase>();

        return services;
    }
}
