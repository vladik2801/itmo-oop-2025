namespace Itmo.ObjectOrientedProgramming.Lab2.Domain;

public abstract record Result
{
    private Result() { }

    public sealed record Succes : Result;

    public sealed record AlreadyRead : Result;

    public sealed record NotFound : Result;
}