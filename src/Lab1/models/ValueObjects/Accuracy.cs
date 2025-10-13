using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.ValueObjects;
public sealed record Accuracy
{
    public readonly double Time;
    public Accuracy(int seconds)
    {
        if (seconds <= 0 ) throw new ArgumentOutOfRangeException(nameof(seconds), "Accuracy must be positive!");
        Time = seconds;
    }
}