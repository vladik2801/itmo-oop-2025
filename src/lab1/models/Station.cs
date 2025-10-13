using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using test.models.ValueObjects;
using Test.Models.ValueObjects;
namespace Test.Models;

public sealed class Station : IRoute
{
    private readonly Time timeBoardByOne;
    private readonly Speed limitSpeed;
    private readonly CountPeople countPeople;
    private readonly double coefficientIncomingPeople = 2;

    public Station(double Limit, int CountPeopleInp)
    {
        timeBoardByOne = new Time(2d/60);
        limitSpeed = new Speed(Limit);
        countPeople = new CountPeople(CountPeopleInp);
    }
    public bool IsValidLimit(double value)
    {
        if (value < limitSpeed.speed) return true;
        return false;
    }
    public double MakeTimeWaitingBoard() => countPeople.Count * timeBoardByOne.time;

    public void Simulate(Train train, Result result)
    {
        if (!this.IsValidLimit(train.speed.speed)) result.MakeFalse();

        result.AddTimeValue(this.MakeTimeWaitingBoard() * coefficientIncomingPeople);
    }

}
