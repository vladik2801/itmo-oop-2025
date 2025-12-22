namespace Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;

public readonly record struct PinCode
{
    public PinCode(int value)
    {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "Pin code must be better than 0");
        Value = value;
    }

    public int Value { get; }
}