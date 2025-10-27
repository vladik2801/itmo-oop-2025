namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

public readonly record struct NonEmptyText
{
    public string Value { get; }

    private NonEmptyText(string value)
    {
        Value = value;
    }

    public static Result<NonEmptyText> TryCreate(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return Result<NonEmptyText>.Fail("Empty text", "Value cannot be null or empty");
        }

        return Result<NonEmptyText>.Ok(new(value));
    }

    public static implicit operator string(NonEmptyText value) => value.Value;

    public static implicit operator NonEmptyText(string s) => new(s);
}