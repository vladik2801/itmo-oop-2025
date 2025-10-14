namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Power
{
    public double Nutone { get; }

    public Power(double powerInp)
    {
        Nutone = powerInp;
    }
}