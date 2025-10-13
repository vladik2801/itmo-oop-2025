using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models;

using test.models.ValueObjects;
using Test.Models.ValueObjects;
public sealed class RailPath : IRoute
{
    private Length totalLength;

    public RailPath(double Length)
    {
        this.totalLength = new Length(Length);
    }
    public void MinusLength(double Length) => totalLength = new(totalLength.length - Length);
     

    public bool IsZeroMore() => totalLength.length > 0;

    public void Simulate(Train train, Result result)
    {
        if (train.Boost.boost == 0 && train.speed.speed <= 0 || train.speed.speed < 0)
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


