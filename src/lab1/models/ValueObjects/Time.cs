using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.ValueObjects;
public sealed record Time
{
    public readonly double time;
    public Time(double timeInp)
    {
        if (timeInp < 0) throw new ArgumentOutOfRangeException(nameof(timeInp), "Time must be positive!");
        this.time = timeInp;
    }
    
}
