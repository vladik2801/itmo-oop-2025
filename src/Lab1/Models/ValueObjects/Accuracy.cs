namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Accuracy
{
    public readonly double Time;

    public Accuracy(int seconds)
    {
        if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds), "Accuracy must be positive!");
        Time = seconds;
    }
}