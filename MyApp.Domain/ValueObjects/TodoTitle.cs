namespace MyApp.Domain.ValueObjects;

/// <summary>
/// Value Object del titulo del Todo.
/// Regla de dominio: no exede de 6 caracteres.
/// </summary>
public sealed class TodoTitle : IEquatable<TodoTitle>
{
    public string Value { get; }

    private TodoTitle(string value)
    {
        Value = value;
    }

    public static TodoTitle Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Title requerido.", nameof(value));
        }

        var normalized = value.Trim();

        if (normalized.Length > 6)
        {
            throw new ArgumentException("Title no puede exceder de 6 caracteres.", nameof(value));
        }

        return new TodoTitle(normalized);
    }

    public bool Equals(TodoTitle? other)
    {
        if (other is null) return false;
        return string.Equals(Value, other.Value, StringComparison.Ordinal);
    }

    public override bool Equals(object? obj) => Equals(obj as TodoTitle);

    public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(Value);

    public override string ToString() => Value;
}

