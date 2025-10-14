namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Accuracy
{
    public double Time { get; }

    public Accuracy(int seconds)
    {
        if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds), "Accuracy must be positive!");
        Time = seconds;
    }
}