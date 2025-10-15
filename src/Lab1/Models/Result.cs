using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Result
{
    public bool IsSuccessfully { get; private set; }

    public Time TimeTrain { get; private set; }

    public Result(bool isSuccessfully, double time = 0)
    {
        IsSuccessfully = isSuccessfully;
        TimeTrain = new(time);
    }

    public string MakeResult()
    {
        if (IsSuccessfully)
        {
            Rounding();
            return "Successfully! Time:" + TimeTrain.ToString();
        }

        return "Fail!";
    }

    public void MakeFalse() => IsSuccessfully = false;

    public void AddTimeValue(double value)
    {
        TimeTrain = new(value + TimeTrain.Seconds);
        Rounding();
    }

    private void Rounding() => TimeTrain = new(Math.Round(TimeTrain.Seconds, 2));
}