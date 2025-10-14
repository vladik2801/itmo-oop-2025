using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class RailPath : IRoute
{
    private Length totalLength;

    public RailPath(double length)
    {
        this.totalLength = new Length(length);
    }

    public void MinusLength(double length) => totalLength = new(totalLength.length - length);

    public bool IsZeroMore() => totalLength.length > 0;

    public void Simulate(Train train, Result result)
    {
        if ((train.Boost.boost == 0 && train.speed.speed <= 0) || (train.speed.speed < 0))
        {
            result.MakeFalse();
            return;
        }

        train.Boost = new(0);
        while (this.IsZeroMore())
        {
            result.AddTimeValue(train.accuracy.Time);
            train.MakeSpeed();
            this.MinusLength(train.GetDistance());
        }
    }
}