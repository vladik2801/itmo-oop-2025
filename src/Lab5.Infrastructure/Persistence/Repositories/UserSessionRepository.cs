using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Lab5.Infrastructure.Persistence.Repositories;

public sealed class UserSessionRepository : IUserSessionRepository
{
    private readonly Dictionary<SessionId, UserSession> _userSessions = new();

    public UserSession Add(UserSession userSession)
    {
        _userSessions[userSession.Id] = userSession;
        return userSession;
    }

    public IEnumerable<UserSession> Query(UserSessionQuery query)
    {
        return _userSessions
            .Where(pair => query.Ids.Contains(pair.Key))
            .Select(pair => pair.Value);
    }
}