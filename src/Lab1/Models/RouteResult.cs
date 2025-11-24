using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract record RouteResult
{
    private RouteResult() { }

    public sealed record SuccessRoute(Time Time) : RouteResult;

    public sealed record ErrorRoute(string LogError) : RouteResult;
}