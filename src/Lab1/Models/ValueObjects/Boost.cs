namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Boost
{
    public Boost(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public Boost CreateFromPowerAndWeight(Power power, Weight weight)
    {
        return new(power.Value / weight.Value);
    }
}