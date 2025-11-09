using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Station : IRoute
{
    private readonly Time _timeBoardByOne;
    private readonly Speed _limitSpeed;
    private readonly CountPeople _countPeople;
    private readonly double _coefficientIncomingPeople = 2;

    public Station(Speed limit, CountPeople countPeopleInp)
    {
        _timeBoardByOne = new Time(0.03);
        _limitSpeed = limit;
        _countPeople = countPeopleInp;
    }

    public bool IsValidLimit(Speed value) => value < _limitSpeed;

    public Time MakeTimeWaitingBoard() => new(_countPeople.Value * _timeBoardByOne.Value * _coefficientIncomingPeople);
}