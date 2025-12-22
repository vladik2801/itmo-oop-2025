namespace Itmo.ObjectOrientedProgramming.Lab5.Results;

public abstract record CreateAccountResult
{
    private CreateAccountResult() { }

    public sealed record Success : CreateAccountResult;

    public sealed record Failure(string Message) : CreateAccountResult;
}