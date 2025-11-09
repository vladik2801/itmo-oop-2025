namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Accuracy
{
    public Accuracy(int value)
    {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value), "Accuracy must be positive!");
        Value = value;
    }

    public double Value { get; }
}