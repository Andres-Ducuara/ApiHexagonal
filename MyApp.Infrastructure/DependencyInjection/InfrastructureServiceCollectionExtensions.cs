using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Ports;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Adapter in-memory: reemplazar por EF Core/otro storage será un cambio aislado en Infrastructure.
        services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();
        return services;
    }
}

