namespace Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;

public readonly record struct AccountId
{
    public AccountId(long value)
    {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "Account number must be positive");
        Value = value;
    }

    public long Value { get; }
}