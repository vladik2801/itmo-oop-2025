namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

public sealed record Weight
{
    public double Kilograms { get; }

    public Weight(double kilograms)
    {
        if (kilograms < 300)
        {
            string name = nameof(kilograms);
            throw new ArgumentOutOfRangeException(
                name,
                "The weight of the train cannot be less than 300 kg.");
        }

        this.Kilograms = kilograms;
    }
}