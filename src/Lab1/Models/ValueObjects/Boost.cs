namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Boost
{
    public readonly double boost;

    public Boost(double boostInp)
    {
        boost = boostInp;
    }
}