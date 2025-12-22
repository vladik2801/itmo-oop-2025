using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Lab5.Infrastructure.Persistence;

public sealed class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(
        IAccountRepository accounts,
        IUserSessionRepository userSessions,
        IAdminSessionRepository adminSessions,
        IOperationHistoryRepository operationHistory)
    {
        Accounts = accounts;
        UserSessions = userSessions;
        AdminSessions = adminSessions;
        OperationHistory = operationHistory;
    }

    public IAccountRepository Accounts { get; }

    public IUserSessionRepository UserSessions { get; }

    public IAdminSessionRepository AdminSessions { get; }

    public IOperationHistoryRepository OperationHistory { get; }
}