using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Results;

public abstract record WithdrawResult
{
    private WithdrawResult() { }

    public sealed record Success(Money NewBalance) : WithdrawResult;

    public sealed record Failure(string Message) : WithdrawResult;
}