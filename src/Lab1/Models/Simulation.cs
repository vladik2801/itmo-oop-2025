namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Simulation
{
    public Result ResultSimulation { get; } = new(true, 0);

    public void Calculator(Train train, params IRoute[] way)
    {
        foreach (IRoute route in way)
        {
            route.Simulate(train, ResultSimulation);
            if (!ResultSimulation.IsSuccessfully) break;
        }

        if (!train.IsNormalSpeed(train.SpeedTrain.SpeedMC)) ResultSimulation.MakeFalse();
    }
}