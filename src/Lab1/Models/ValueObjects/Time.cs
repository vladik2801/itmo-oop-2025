namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Time
{
    public double Seconds { get; }

    public Time(double timeInp)
    {
        if (timeInp < 0) throw new ArgumentOutOfRangeException(nameof(timeInp), "Time must be positive!");
        Seconds = timeInp;
    }
}