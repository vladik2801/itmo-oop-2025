using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Lab5.Infrastructure.Persistence.Repositories;

public sealed class AdminSessionRepository : IAdminSessionRepository
{
    private readonly Dictionary<SessionId, AdminSession> _sessions = new();

    public AdminSession Add(AdminSession adminSession)
    {
        _sessions[adminSession.Id] = adminSession;
        return adminSession;
    }

    public IEnumerable<AdminSession> Query(AdminSessionQuery query)
    {
        return _sessions
            .Where(pair => query.Ids.Contains(pair.Key))
            .Select(pair => pair.Value);
    }
}