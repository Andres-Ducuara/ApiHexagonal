using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Dtos;
using MyApp.Application.UseCases;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TodosController : ControllerBase
{
    private readonly CreateTodoUseCase _createTodoUseCase;
    private readonly GetTodoByIdUseCase _getTodoByIdUseCase;
    private readonly UpdateTodoEmailUseCase _updateTodoEmailUseCase;

    public TodosController(
        CreateTodoUseCase createTodoUseCase,
        GetTodoByIdUseCase getTodoByIdUseCase,
        UpdateTodoEmailUseCase updateTodoEmailUseCase)
    {
        _createTodoUseCase = createTodoUseCase;
        _getTodoByIdUseCase = getTodoByIdUseCase;
        _updateTodoEmailUseCase = updateTodoEmailUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<TodoDto>> Create(
        [FromBody] CreateTodoRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var todo = await _createTodoUseCase.ExecuteAsync(request.Title, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TodoDto>> GetById(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var todo = await _getTodoByIdUseCase.ExecuteAsync(id, cancellationToken);
        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    public sealed record CreateTodoRequest(string Title);

    [HttpPatch("{id:guid}/email")]
    public async Task<ActionResult<TodoDto>> UpdateEmail(
        [FromRoute] Guid id,
        [FromBody] UpdateEmailRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var todo = await _updateTodoEmailUseCase.ExecuteAsync(id, request.Email, cancellationToken);
            if (todo is null)
            {
                return NotFound();
            }

            return Ok(todo);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    public sealed record UpdateEmailRequest(string Email);
}

