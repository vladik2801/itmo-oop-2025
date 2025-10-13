using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Test.Models;

public sealed class Simulation
{
    public Result result = new Result(true, 0);
    public Result Calculator(Train Train, params IRoute[] way)
    {
        var Result = new Result(false, 0);
        foreach (var route in way)
        {
            route.Simulate(Train, result);
            if (!result.IsSuccessfully) break;

        }
        if (!Train.IsNormalSpeed(Train.speed.speed)) result.MakeFalse();
        return result;
    }

}