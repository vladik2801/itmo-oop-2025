using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Train
{
    private readonly Weight weight;
    private readonly Speed limitSpeed;

    public Accuracy AccuracyTrain { get; }

    public Power MaxPower { get; }

    public Speed SpeedTrain { get; private set; }

    public Power PowerTrain { get; private set; }

    public Boost Boost { get; set; }

    public Train(double weightInp, double maxpower, int time, double limitRoute)
    {
        weight = new Weight(weightInp);
        MaxPower = new Power(maxpower);
        AccuracyTrain = new Accuracy(time);
        limitSpeed = new Speed(limitRoute);
        PowerTrain = new Power(0);
        SpeedTrain = new Speed(0);

        Boost = new Boost(0);
    }

    public bool TryCalculationBoost(double powerInp)
    {
        if (MaxPower.Nutone >= powerInp + PowerTrain.Nutone)
        {
            PowerTrain = new(PowerTrain.Nutone + powerInp);

            Boost = new((powerInp + PowerTrain.Nutone) / weight.Kilograms);
            return true;
        }

        return false;
    }

    public bool IsNormalSpeed(double speed) => speed <= limitSpeed.SpeedMC;

    public void MakeSpeed()
    {
        double newSpeed = AccuracyTrain.Time * Boost.BoostMC;
        SpeedTrain = new(SpeedTrain.SpeedMC + newSpeed);
    }

    public double GetDistance() => SpeedTrain.SpeedMC * AccuracyTrain.Time;
}