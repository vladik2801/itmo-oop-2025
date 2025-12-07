namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public abstract record OperationResult
{
    private OperationResult() { }

    public sealed record Succes : OperationResult;

    public sealed record Failure(string Message) : OperationResult;
}