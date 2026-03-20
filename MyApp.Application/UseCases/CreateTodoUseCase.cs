using MyApp.Application.Dtos;
using MyApp.Application.Ports;
using MyApp.Domain.Entities;

namespace MyApp.Application.UseCases;

public sealed class CreateTodoUseCase
{
    private readonly ITodoRepository _todoRepository;

    public CreateTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoDto> ExecuteAsync(string title, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title es requerido.", nameof(title));
        }

        var todo = Todo.Create(Guid.NewGuid(), title);
        await _todoRepository.AddAsync(todo, cancellationToken);

        return new TodoDto(todo.Id, todo.Title, todo.IsCompleted, Email: todo.Email?.Value);
    }

}

