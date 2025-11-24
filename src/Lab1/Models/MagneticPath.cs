using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class MagneticPath : IRoute
{
    public MagneticPath(Length length, Power powerInp)
    {
        Power = powerInp;
        TotalLength = length;
    }

    public Power Power { get; }

    public Length TotalLength { get; }
}