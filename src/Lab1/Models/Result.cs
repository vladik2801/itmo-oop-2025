using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Result
{
    private Outcome _value;

    public bool IsSuccessfully => _value.IsSuccessfully;

    public Time TimeTrain => new(_value.TimeSeconds);

    public Result(bool isSuccessfully, double time = 0)
    {
        _value = new Outcome(isSuccessfully, time);
    }

    public string MakeResult()
    {
        if (IsSuccessfully)
        {
            _value = _value.Rounded();
            return "Successfully! Time:" + TimeTrain.ToString();
        }

        return "Fail!";
    }

    public void MakeFalse() => _value = _value with { IsSuccessfully = false };

    public void AddTimeValue(double value) => _value = _value.Add(value).Rounded();

    private readonly record struct Outcome(bool IsSuccessfully, double TimeSeconds)
    {
        public Outcome Add(double value) => IsSuccessfully ? this with { TimeSeconds = TimeSeconds + value } : this;

        public Outcome Rounded() => this with { TimeSeconds = Math.Round(TimeSeconds, 2) };
    }
}