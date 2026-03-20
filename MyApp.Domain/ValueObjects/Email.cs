using System.Text.RegularExpressions;

namespace MyApp.Domain.ValueObjects;

/// <summary>
/// Value Object que encapsula la validacion del email.
/// </summary>
public sealed class Email : IEquatable<Email>
{
    private static readonly Regex EmailRegex =
        // Validacion basica (suficiente para este ejercicio).
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Email requerido.", nameof(value));
        }

        var normalized = value.Trim();

        if (!EmailRegex.IsMatch(normalized))
        {
            throw new ArgumentException("Email invalido.", nameof(value));
        }

        return new Email(normalized.ToLowerInvariant());
    }

    public bool Equals(Email? other)
    {
        if (other is null) return false;
        return string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj) => Equals(obj as Email);

    public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(Value);

    public override string ToString() => Value;
}

