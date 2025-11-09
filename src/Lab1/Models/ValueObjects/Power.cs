namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Power
{
    public Power(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public static Power operator +(Power power1, Power power2)
    {
        return new(power1.Value + power2.Value);
    }

    public static bool operator >=(Power power1, Power power2)
    {
        return power1.Value >= power2.Value;
    }

    public static bool operator <=(Power power1, Power power2)
    {
        return power1.Value <= power2.Value;
    }

    public static bool operator <(Power power1, Power power2)
    {
        return power1.Value < power2.Value;
    }

    public static bool operator >(Power power1, Power power2)
    {
        return power1.Value > power2.Value;
    }
}