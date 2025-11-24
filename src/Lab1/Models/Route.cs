using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class Route
{
    private readonly List<IRoute> _routes;

    private readonly Speed _limitSpeed;

    private Time _timeRoute;

    public Route(IEnumerable<IRoute> routes, Speed limitSpeed)
    {
        _routes = routes.ToList();
        _limitSpeed = limitSpeed;
        _timeRoute = new(0);
    }

    public RouteResult Move(Train train)
    {
        Time newTime = new(0);
        MoveResult moveResult;
        foreach (IRoute route in _routes)
        {
            (newTime, moveResult) = train.CompletingDistance(route);
            _timeRoute += newTime;
            if (moveResult is MoveResult.ErrorRoute(var log)) return new RouteResult.ErrorRoute(log);
        }

        if (train.SpeedTrain > _limitSpeed) return new RouteResult.ErrorRoute("Limit route speed");
        return new RouteResult.SuccessRoute(_timeRoute);
    }
}