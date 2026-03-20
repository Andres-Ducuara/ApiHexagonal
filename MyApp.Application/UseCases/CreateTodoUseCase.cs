using MyApp.Application.Dtos;
using MyApp.Application.Ports;
using MyApp.Domain.Entities;
using MyApp.Domain.ValueObjects;

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
        var titleVo = TodoTitle.Create(title);
        var todo = Todo.Create(Guid.NewGuid(), titleVo);
        await _todoRepository.AddAsync(todo, cancellationToken);

        return new TodoDto(todo.Id, todo.Title.Value, todo.IsCompleted, Email: todo.Email?.Value);
    }

}

