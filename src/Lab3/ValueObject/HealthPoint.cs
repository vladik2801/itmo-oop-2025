namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

public sealed record HealthPoint
{
    public HealthPoint(int value)
    {
        Value = value;
    }

    public int Value { get; set; }
}