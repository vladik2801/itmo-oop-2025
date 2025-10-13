using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.ValueObjects;
public sealed record Power
{
    public readonly double power;
    public Power(double powerInp)
    {
        power = powerInp;
    }
    
    
}