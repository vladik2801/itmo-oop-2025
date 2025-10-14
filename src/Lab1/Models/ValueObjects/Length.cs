namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Length
{
    public readonly double length;

    public Length(double kilometres)
    {
        length = kilometres;
    }
}