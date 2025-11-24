namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract record MoveResult
{
    private MoveResult() { }

    public sealed record Success : MoveResult;

    public sealed record ErrorRoute(string LogErrorMove) : MoveResult;
}