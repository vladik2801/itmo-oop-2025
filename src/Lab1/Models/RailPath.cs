using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class RailPath : IRoute
{
    private Length totalLength;

    public RailPath(double length)
    {
        totalLength = new Length(length);
    }

    public void MinusLength(double length) => totalLength = new(totalLength.Metres - length);

    public bool IsZeroMore() => totalLength.Metres > 0;

    public void Simulate(Train train, Result result)
    {
        if ((train.Boost.BoostMC == 0 && train.SpeedTrain.SpeedMC <= 0) || (train.SpeedTrain.SpeedMC < 0))
        {
            result.MakeFalse();
            return;
        }

        train.Boost = new(0);
        while (IsZeroMore())
        {
            result.AddTimeValue(train.AccuracyTrain.Time);
            train.MakeSpeed();
            MinusLength(train.GetDistance());
        }
    }
}