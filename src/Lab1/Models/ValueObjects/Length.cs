namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Length
{
    public double Metres { get; }

    public Length(double metres)
    {
        Metres = metres;
    }
}