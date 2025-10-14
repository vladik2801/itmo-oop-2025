namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Simulation
{
    public Result ResultSimulation { get; } = new Result(true, 0);

    public Result Calculator(Train train, params IRoute[] way)
    {
        var result = new Result(false, 0);
        foreach (IRoute route in way)
        {
            route.Simulate(train, result);
            if (!result.IsSuccessfully) break;
        }

        if (!train.IsNormalSpeed(train.SpeedTrain.SpeedMC)) result.MakeFalse();
        return result;
    }
}