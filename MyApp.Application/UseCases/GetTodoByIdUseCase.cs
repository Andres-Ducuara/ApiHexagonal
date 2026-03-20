using MyApp.Application.Dtos;
using MyApp.Application.Ports;

namespace MyApp.Application.UseCases;

public sealed class GetTodoByIdUseCase
{
    private readonly ITodoRepository _todoRepository;

    public GetTodoByIdUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoDto?> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetByIdAsync(id, cancellationToken);
        if (todo is null)
        {
            return null;
        }

        return new TodoDto(todo.Id, todo.Title.Value, todo.IsCompleted, Email: todo.Email?.Value);
    }
}

