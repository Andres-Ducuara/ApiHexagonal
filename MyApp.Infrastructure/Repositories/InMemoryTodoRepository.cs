using System.Collections.Concurrent;
using MyApp.Application.Ports;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Repositories;

public sealed class InMemoryTodoRepository : ITodoRepository
{
    private readonly ConcurrentDictionary<Guid, Todo> _store = new();

    public Task AddAsync(Todo todo, CancellationToken cancellationToken)
    {
        _store[todo.Id] = todo;
        return Task.CompletedTask;
    }

    public Task<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        _store.TryGetValue(id, out var todo);
        return Task.FromResult(todo);
    }

    public Task UpdateAsync(Todo todo, CancellationToken cancellationToken)
    {
        // Como es InMemory, guardamos la referencia actualizada.
        _store[todo.Id] = todo;
        return Task.CompletedTask;
    }
}

