namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Time
{
    public Time(double value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Time must be positive!");
        Value = value;
    }

    public double Value { get; }

    public static Time operator +(Time t1, Time t2) => new(t1.Value + t2.Value);
}