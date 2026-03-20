using MyApp.Domain.Entities;

namespace MyApp.Application.Ports;

public interface ITodoRepository
{
    Task AddAsync(Todo todo, CancellationToken cancellationToken);
    Task<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(Todo todo, CancellationToken cancellationToken);
}

