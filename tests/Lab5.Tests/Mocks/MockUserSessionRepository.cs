using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public sealed class MockUserSessionRepository : IUserSessionRepository
{
    private readonly Dictionary<SessionId, UserSession> _storage = new Dictionary<SessionId, UserSession>();

    public int AddCalls { get; private set; }

    public void Seed(UserSession session)
    {
        _storage[session.Id] = session;
    }

    public IEnumerable<UserSession> Query(UserSessionQuery query)
    {
        return query.Ids
            .Where(id => _storage.ContainsKey(id))
            .Select(id => _storage[id]);
    }

    public UserSession Add(UserSession userSession)
    {
        AddCalls++;
        _storage[userSession.Id] = userSession;
        return userSession;
    }
}