namespace Itmo.ObjectOrientedProgramming.Lab5.Sessions;

public sealed class AdminSession
{
    public AdminSession(SessionId sessionId)
    {
        Id = sessionId;
    }

    public SessionId Id { get; }
}