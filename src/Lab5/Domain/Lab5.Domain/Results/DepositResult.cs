using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Results;

public abstract record DepositResult
{
    private DepositResult() { }

    public sealed record Success(Money NewBalance) : DepositResult;

    public sealed record Failure(string Message) : DepositResult;
}