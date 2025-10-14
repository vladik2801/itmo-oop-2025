namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Boost
{
    public double BoostMC { get; }

    public Boost(double boostInp)
    {
        BoostMC = boostInp;
    }
}