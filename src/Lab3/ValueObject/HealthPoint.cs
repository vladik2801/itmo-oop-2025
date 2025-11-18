namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

public sealed record HealthPoint
{
    public HealthPoint(int value)
    {
        if (value <= 0) throw new ArgumentException("Health points must be >0", nameof(value));
        Value = value;
    }

    public int Value { get; set; }
}