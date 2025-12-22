using Itmo.ObjectOrientedProgramming.Lab5.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Results;

public abstract record CreateUserSessionResult
{
    private CreateUserSessionResult() { }

    public sealed record Success(SessionId SessionId) : CreateUserSessionResult;

    public sealed record AccountNotFound : CreateUserSessionResult;

    public sealed record InvalidPinCode : CreateUserSessionResult;
}