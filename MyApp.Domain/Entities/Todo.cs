using MyApp.Domain.ValueObjects;

namespace MyApp.Domain.Entities;

public sealed class Todo
{
    public Guid Id { get; }
    public TodoTitle Title { get; }
    public bool IsCompleted { get; private set; }
    public Email? Email { get; private set; }

    private Todo(Guid id, TodoTitle title, bool isCompleted)
    {
        Id = id;
        Title = title;
        IsCompleted = isCompleted;
        Email = null;
    }

    public static Todo Create(Guid id, TodoTitle title)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id inválido.", nameof(id));
        }

        if (title is null)
        {
            throw new ArgumentNullException(nameof(title));
        }

        return new Todo(id, title, isCompleted: false);
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

