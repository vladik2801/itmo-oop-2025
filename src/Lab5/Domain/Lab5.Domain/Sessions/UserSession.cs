using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Sessions;

public sealed class UserSession
{
    public UserSession(SessionId sessionId, AccountId accountId)
    {
        Id = sessionId;
        AccountId = accountId;
    }

    public SessionId Id { get; }

    public AccountId AccountId { get; }
}