namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Weight
{
    public Weight(double value)
    {
        if (value < 300)
        {
            string name = nameof(value);
            throw new ArgumentOutOfRangeException(
                name,
                "The weight of the train cannot be less than 300 kg.");
        }

        Value = value;
    }

    public double Value { get; }
}