using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Station : IRoute
{
    private readonly Time timeBoardByOne;
    private readonly Speed limitSpeed;
    private readonly CountPeople countPeople;
    private readonly double coefficientIncomingPeople = 2;

    public Station(double limit, int countPeopleInp)
    {
        timeBoardByOne = new Time(2d / 60);
        limitSpeed = new Speed(limit);
        countPeople = new CountPeople(countPeopleInp);
    }

    public bool IsValidLimit(double value)
    {
        if (value < limitSpeed.SpeedMC) return true;
        return false;
    }

    public double MakeTimeWaitingBoard() => countPeople.Count * timeBoardByOne.Seconds;

    public void Simulate(Train train, Result result)
    {
        if (!this.IsValidLimit(train.SpeedTrain.SpeedMC)) result.MakeFalse();

        result.AddTimeValue(this.MakeTimeWaitingBoard() * coefficientIncomingPeople);
    }
}