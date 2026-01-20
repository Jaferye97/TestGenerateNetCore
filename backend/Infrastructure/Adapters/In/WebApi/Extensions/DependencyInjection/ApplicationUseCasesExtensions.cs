namespace WebApi.Extensions.DependencyInjection;

public static class ApplicationUseCasesExtensions
{
	public static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
    {
        //Example
        //services.AddScoped<IGetCountryByNameUseCase, GetCountryByNameUseCase>();

        return services;
    }
}
