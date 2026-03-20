using MyApp.Domain.ValueObjects;

namespace MyApp.Domain.Entities;

public sealed class Todo
{
    public Guid Id { get; }
    public string Title { get; }
    public bool IsCompleted { get; private set; }
    public Email? Email { get; private set; }

    private Todo(Guid id, string title, bool isCompleted)
    {
        Id = id;
        Title = title;
        IsCompleted = isCompleted;
        Email = null;
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

    /// <summary>
    /// Metodo de dominio relacionado a la propiedad Email.
    /// Permite asignar/cambiar el email asociado al todo.
    /// </summary>
    public void ChangeEmail(Email email)
    {
        if (email is null)
        {
            throw new ArgumentNullException(nameof(email));
        }

        // Invariante simple: si el email no cambia, no hacemos nada.
        if (Email is not null && Email.Equals(email))
        {
            return;
        }

        Email = email;
    }
}

