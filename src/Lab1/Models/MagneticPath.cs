using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class MagneticPath : IRoute
{
    public Power Power { get; private set; }

    private Length totalLength;

    public MagneticPath(double length, double powerInp)
    {
        this.Power = new(powerInp);
        this.totalLength = new Length(length);
    }

    public void MinusLength(double length) => totalLength = new(totalLength.length - length);

    public bool IsZeroMore() => totalLength.length > 0;

    public void Simulate(Train train, Result result)
    {
        if (train.maxPower.power < this.Power.power + train.power.power)
        {
            result.MakeFalse();
            return;
        }

        if (!train.TryCalculationBoost(this.Power.power))
        {
            result.MakeFalse();
            return;
        }

        while (this.IsZeroMore())
        {
            result.AddTimeValue(train.accuracy.Time);

            try
            {
                train.MakeSpeed();
            }
            catch (ArgumentOutOfRangeException)
            {
                result.MakeFalse();
                break;
            }

            MinusLength(train.GetDistance());
        }
    }
}