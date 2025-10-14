namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Power
{
    public readonly double power;

    public Power(double powerInp)
    {
        power = powerInp;
    }
}