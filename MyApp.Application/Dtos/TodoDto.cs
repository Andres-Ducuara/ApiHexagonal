namespace MyApp.Application.Dtos;

public sealed record TodoDto(Guid Id, string Title, bool IsCompleted, string? Email);

