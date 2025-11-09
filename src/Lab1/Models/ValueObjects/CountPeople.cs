namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record CountPeople
{
    public CountPeople(int value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Count of people must be positive!");
        Value = value;
    }

    public int Value { get; }
}