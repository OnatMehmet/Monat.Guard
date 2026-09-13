using System.Runtime.CompilerServices;

namespace Monat.Guard;
/// <summary>
/// Provides guard clauses for validating method arguments.
/// </summary>
public static class Guard
{
    /// <summary>
    /// Ensures that the specified value is not null.
    /// </summary>
    public static void NotNull(
        object? value,
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        ArgumentNullException.ThrowIfNull(value, paramName);
    }

    /// <summary>
    /// Ensures that the specified value is NotNullOrWhiteSpace.
    /// </summary>
    public static void NotNullOrWhiteSpace(
        string? value,
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                "Value cannot be null or whitespace.",
                paramName);
        }
    }

    /// <summary>
    /// Ensures that the specified value is NotEmpty.
    /// </summary>
    public static void NotEmpty(
        Guid value,
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException(
                "Guid cannot be empty.",
                paramName);
        }
    }

    /// <summary>
    /// Ensures that the specified value is Positive.
    /// </summary>
    public static void Positive(
        int value,
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(
                paramName,
                value,
                "Value must be greater than zero.");
        }
    }

    /// <summary>
    /// Ensures that the specified value is NotNegative.
    /// </summary>
    public static void NotNegative(
        decimal value,
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(
                paramName,
                value,
                "Value cannot be negative.");
        }
    }

    /// <summary>
    /// Ensures that the specified value is NotDefault.
    /// </summary>
    public static void NotDefault<T>(
        T value,
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (EqualityComparer<T>.Default.Equals(value, default))
        {
            throw new ArgumentException(
                "Value cannot be the default value.",
                paramName);
        }
    }

    /// <summary>
    /// Ensures that the specified value is in the range.
    /// </summary>
    public static void InRange(
        int value,
        int min,
        int max,
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (value < min || value > max)
        {
            throw new ArgumentOutOfRangeException(
                paramName,
                value,
                $"Value must be between {min} and {max}.");
        }
    }
    /// <summary>
    /// Ensures that the specified value is NotNullOrEmpty.
    /// </summary>
    public static void NotNullOrEmpty<T>(
        IEnumerable<T>? value,
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (value is null || !value.Any())
        {
            throw new ArgumentException(
                "Collection cannot be null or empty.",
                paramName);
        }
    }
}