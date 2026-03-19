using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.UseCases;

namespace MyApp.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateTodoUseCase>();
        services.AddScoped<GetTodoByIdUseCase>();

        return services;
    }
}

