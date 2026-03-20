using MyApp.Application.Dtos;
using MyApp.Application.Ports;
using MyApp.Domain.ValueObjects;

namespace MyApp.Application.UseCases;

public sealed class UpdateTodoEmailUseCase
{
    private readonly ITodoRepository _todoRepository;

    public UpdateTodoEmailUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoDto?> ExecuteAsync(Guid id, string email, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetByIdAsync(id, cancellationToken);
        if (todo is null)
        {
            return null;
        }

        var emailVo = Email.Create(email);
        todo.ChangeEmail(emailVo);

        await _todoRepository.UpdateAsync(todo, cancellationToken);

        return new TodoDto(todo.Id, todo.Title.Value, todo.IsCompleted, Email: todo.Email?.Value);
    }
}

