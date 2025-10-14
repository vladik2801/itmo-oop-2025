namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record CountPeople
{
    public readonly int Count;

    public CountPeople(int count)
    {
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "Count of people must be positive!");
        Count = count;
    }
}