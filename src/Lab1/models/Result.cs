using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test.Models.ValueObjects;
namespace Test.Models;

public sealed class Result
{
    public bool IsSuccessfully { get; private set; }
    public Time Time; 

    public Result(bool isSuccessfully, double time = 0)
    {
        this.IsSuccessfully = isSuccessfully;
        if (isSuccessfully) this.Time = new(time);
    }
    public string MakeResult()
    {
        if (IsSuccessfully)
        {
            Rounding();
            return "Successfully! Time:" + Time.ToString();

        }

        return ("Fail!");
    }
    public void MakeFalse() => IsSuccessfully = false;

    private void Rounding() => Time = new(Math.Round(Time.time, 2));

    public void AddTimeValue(double value)
    {
        Time = new(value + Time.time);
        Rounding();
    }

}