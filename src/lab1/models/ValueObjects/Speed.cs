using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.models.ValueObjects;

public sealed record Speed
{
    public readonly double speed;
    public Speed(double SpeedInp)
    {
        if (SpeedInp < 0) throw new ArgumentOutOfRangeException(nameof(SpeedInp), "Speed must be positive!");
        speed = SpeedInp;
    }
    

}
