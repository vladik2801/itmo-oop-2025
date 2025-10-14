using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Train
{
    private readonly Weight weight;
    private readonly Speed limitSpeed;
    public readonly Accuracy accuracy;
    public readonly Power maxPower;
    public Speed speed { get; private set; }
    public Power power { get; private set; }


    public Boost Boost { get; set; }


    public Train(double weightInp, double maxpower, int time, double limitRoute)
    {
        weight = new Weight(weightInp);
        maxPower = new Power(maxpower);
        accuracy = new Accuracy(time);
        limitSpeed = new Speed(limitRoute);
        power = new Power(0);
        speed = new Speed(0);

        Boost = new Boost(0);
    }

    public bool TryCalculationBoost(double powerInp)
    {
        if (maxPower.power >= powerInp + this.power.power)
        {
            power = new(power.power + powerInp);

            Boost = new((powerInp + this.power.power) / weight.Kilograms);
            return true;
        }

        return false;
    }

    public bool IsNormalSpeed(double speed) => speed <= limitSpeed.speed;

    public void MakeSpeed()
    {
        double newSpeed = accuracy.Time * Boost.boost;
        speed = new(speed.speed + newSpeed);
    }

    public double GetDistance() => speed.speed * accuracy.Time;
}