namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Length
{
    public Length(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public static Length operator -(Length length1, Length length2)
    {
        return new Length(length1.Value - length2.Value);
    }
}