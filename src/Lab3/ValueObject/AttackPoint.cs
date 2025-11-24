namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObject;

public sealed record AttackPoint
{
    public AttackPoint(int value)
    {
        if (value <= 0) throw new ArgumentException("Attack point must be >= 0", nameof(value));
        Value = value;
    }

    public int Value { get; set; }
}