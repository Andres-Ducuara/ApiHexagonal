namespace MyApp.Domain.Entities;

public sealed class Todo
{
    public Guid Id { get; }
    public string Title { get; }
    public bool IsCompleted { get; private set; }

    private Todo(Guid id, string title, bool isCompleted)
    {
        Id = id;
        Title = title;
        IsCompleted = isCompleted;
    }

    public static Todo Create(Guid id, string title)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id inválido.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title requerido.", nameof(title));
        }

        return new Todo(id, title.Trim(), isCompleted: false);
    }
}

