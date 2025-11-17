namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

public sealed record NonEmptyText
{
    public NonEmptyText(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Text can not be empty", nameof(value));
        }

        Value = value;
    }

    public string Value { get; }
}