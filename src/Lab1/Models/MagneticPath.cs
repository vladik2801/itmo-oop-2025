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

    public void MinusLength(double length) => totalLength = new(totalLength.Metres - length);

    public bool IsZeroMore() => totalLength.Metres > 0;

    public void Simulate(Train train, Result result)
    {
        if (train.MaxPower.Nutone < this.Power.Nutone + train.PowerTrain.Nutone)
        {
            result.MakeFalse();
            return;
        }

        if (!train.TryCalculationBoost(this.Power.Nutone))
        {
            result.MakeFalse();
            return;
        }

        while (this.IsZeroMore())
        {
            result.AddTimeValue(train.AccuracyTrain.Time);

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