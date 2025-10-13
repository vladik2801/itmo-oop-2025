using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Test.Models.ValueObjects;
public sealed record Length
{
    public readonly double length;
    
    public Length(double Kilometres)
    {
        length = Kilometres;
    }
   
  
   
}
