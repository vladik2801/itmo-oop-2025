using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public sealed class MockAdminSessionRepository : IAdminSessionRepository
{
    private readonly Dictionary<SessionId, AdminSession> _storage = new Dictionary<SessionId, AdminSession>();

    public int AddCalls { get; private set; }

    public void Seed(AdminSession session)
    {
        _storage[session.Id] = session;
    }

    public IEnumerable<AdminSession> Query(AdminSessionQuery query)
    {
        return query.Ids
            .Where(id => _storage.ContainsKey(id))
            .Select(id => _storage[id]);
    }

    public AdminSession Add(AdminSession adminSession)
    {
        AddCalls++;
        _storage[adminSession.Id] = adminSession;
        return adminSession;
    }
}