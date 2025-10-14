namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Simulation
{
    public Result result = new Result(true, 0);

    public Result Calculator(Train train, params IRoute[] way)
    {
        var Result = new Result(false, 0);
        foreach (IRoute route in way)
        {
            route.Simulate(train, result);
            if (!result.IsSuccessfully) break;
        }

        if (!train.IsNormalSpeed(train.speed.speed)) result.MakeFalse();
        return result;
    }
}