using Itmo.ObjectOrientedProgramming.Lab5.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Results;

public abstract record CreateAdminSessionResult
{
    private CreateAdminSessionResult() { }

    public sealed record Success(SessionId SessionId) : CreateAdminSessionResult;

    public sealed record InvalidPassword : CreateAdminSessionResult;
}