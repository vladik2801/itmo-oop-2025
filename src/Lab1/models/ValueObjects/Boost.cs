using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.models.ValueObjects;

public sealed record Boost
{
    public readonly double boost;
    public Boost(double BoostInp)
    {
        boost = BoostInp;
    }
   
       
   
}
