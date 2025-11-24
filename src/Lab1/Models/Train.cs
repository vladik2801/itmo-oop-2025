using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Train
{
    private readonly Weight _weight;

    private readonly Time _accuracyTrain;

    private readonly Power _maxPower;

    private Boost _boost;

    private Power _powerTrain;

    public Train(Weight weightInp, Power maxPower, Time time)
    {
        _weight = weightInp;
        _maxPower = maxPower;
        _accuracyTrain = time;
        _powerTrain = new Power(0);
        SpeedTrain = new Speed(0);
        _boost = new Boost(0);
    }

    public Speed SpeedTrain { get; private set; }

    public MoveResult TryCalculationBoost(Power powerInp)
    {
        if (_powerTrain.Value + powerInp.Value > _maxPower.Value)
            return new MoveResult.ErrorRoute("Limit train power");

        _powerTrain += powerInp;
        _boost = _boost.CreateFromPowerAndWeight(_powerTrain, _weight);
        return new MoveResult.Success();
    }

    public MoveResult TryMakeSpeedSafe()
    {
        if (!Speed.TryCreate(_boost, _accuracyTrain)) return new MoveResult.ErrorRoute("Speed is negative");
        SpeedTrain = SpeedTrain.CreateSpeedFromBoostAndAccuracy(_boost, _accuracyTrain);
        return new MoveResult.Success();
    }

    public (Time Time, MoveResult MoveResult) CompletingDistance(IRoute route)
    {
        return route switch
        {
            Station station => CompletingStation(station),
            RailPath railPath => CompletingRailPath(railPath),
            MagneticPath magneticPath => CompletingMagneticPath(magneticPath),
            _ => (new Time(0), new MoveResult.ErrorRoute("Unknown route type")),
        };
    }

    public (Time Time, MoveResult MoveResult) CompletingStation(Station station)
    {
        if (!station.IsValidLimit(SpeedTrain)) return (new(0), new MoveResult.ErrorRoute("Limit station speed"));
        Time resultTime = station.MakeTimeWaitingBoard();
        return (resultTime, new MoveResult.Success());
    }

    public (Time Time, MoveResult MoveResult) CompletingRailPath(RailPath route)
    {
        if ((_boost.Value == 0 && SpeedTrain.Value <= 0) || (SpeedTrain.Value < 0))
        {
            return (new Time(0), new MoveResult.ErrorRoute("Boost or speed is equal Zero"));
        }

        _boost = new(1);
        Length totalLength = route.TotalLength;
        Time totalTime = new(0);
        while (totalLength.Value > 0)
        {
            totalTime += _accuracyTrain;
            if (TryMakeSpeedSafe() is MoveResult.ErrorRoute)
                return (new Time(0), new MoveResult.ErrorRoute("Speed is negative"));
            Length newLength = new(SpeedTrain.Value * _accuracyTrain.Value);
            totalLength -= newLength;
        }

        return (totalTime, new MoveResult.Success());
    }

    public (Time Time, MoveResult MoveResult) CompletingMagneticPath(MagneticPath route)
    {
        if (TryCalculationBoost(route.Power) is MoveResult.ErrorRoute)
        {
            return (new Time(0), new MoveResult.ErrorRoute("Limit train power"));
        }

        Length totalLength = route.TotalLength;
        Time totalTime = new(0);
        while (totalLength.Value > 0)
        {
            totalTime += _accuracyTrain;

            if (TryMakeSpeedSafe() is MoveResult.ErrorRoute)
            {
                return (new Time(0), new MoveResult.ErrorRoute("Speed is negative"));
            }

            if (TryCalculationBoost(route.Power) is MoveResult.ErrorRoute)
                return (new Time(0), new MoveResult.ErrorRoute("Limit train power"));
            Length moveDistance = new(SpeedTrain.Value * _accuracyTrain.Value);
            totalLength -= moveDistance;
        }

        return (totalTime, new MoveResult.Success());
    }
}