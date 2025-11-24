namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Speed
{
    public Speed(double value)
    {
        if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Speed must be positive!");
        Value = value;
    }

    public double Value { get; }

    public Speed CreateSpeedFromBoostAndAccuracy(Boost boost, Time accuracy)
    {
        return new(boost.Value * accuracy.Value);
    }

    public static bool TryCreate(Boost boost, Time accuracy)
    {
        double speed = boost.Value * accuracy.Value;
        return speed >= 0;
    }

    public static bool operator <(Speed speed1, Speed speed2)
    {
        return speed1.Value < speed2.Value;
    }

    public static bool operator >(Speed speed1, Speed speed2)
    {
        return speed1.Value > speed2.Value;
    }

    public static bool operator <=(Speed speed1, Speed speed2)
    {
        return speed1.Value <= speed2.Value;
    }

    public static bool operator >=(Speed speed1, Speed speed2)
    {
        return speed1.Value >= speed2.Value;
    }
}