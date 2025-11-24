using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class RailPath : IRoute
{
    public RailPath(Length length)
    {
        TotalLength = length;
    }

    public Length TotalLength { get; }
}