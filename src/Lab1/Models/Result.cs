using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Result
{
    public bool IsSuccessfully { get; private set; }

    private Time Time;

    public Result(bool isSuccessfully, double time = 0)
    {
        this.IsSuccessfully = isSuccessfully;
        this.Time = new(time);
    }

    public string MakeResult()
    {
        if (IsSuccessfully)
        {
            Rounding();
            return "Successfully! Time:" + Time.ToString();
        }

        return "Fail!";
    }

    public void MakeFalse() => IsSuccessfully = false;

    public void AddTimeValue(double value)
    {
        Time = new(value + Time.time);
        Rounding();
    }

    private void Rounding() => Time = new(Math.Round(Time.time, 2));
}