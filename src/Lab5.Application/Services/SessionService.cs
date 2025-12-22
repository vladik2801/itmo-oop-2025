using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;
using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Operations;

namespace Lab5.Application.Services;

public class SessionService : ISessionService
{
    private readonly IPersistenceContext _persistenceContext;
    private readonly string _systemPassword;

    public SessionService(IPersistenceContext persistenceContext, string systemPassword)
    {
        _persistenceContext = persistenceContext;
        _systemPassword = systemPassword;
    }

    public CreateUserSessionOperation.Response CreateUserSession(
        CreateUserSessionOperation.Request request)
    {
        var accountId = new AccountId(request.AccountId);

        Account? account = _persistenceContext.Accounts
            .Query(new AccountQuery(new[] { accountId }))
            .FirstOrDefault();

        if (account is null)
            return new CreateUserSessionOperation.Response.Failure("Account not found");

        if (!account.PinCode.Equals(new PinCode(request.PinCode)))
            return new CreateUserSessionOperation.Response.Failure("Invalid pin code");

        var sessionId = new SessionId(Guid.NewGuid());

        _persistenceContext.UserSessions.Add(
            new UserSession(sessionId, accountId));

        return new CreateUserSessionOperation.Response.Success(sessionId.Value);
    }

    public CreateAdminSessionOperation.Response CreateAdminSession(
        CreateAdminSessionOperation.Request request)
    {
        if (request.SystemPassword != _systemPassword)
            return new CreateAdminSessionOperation.Response.Failure("Invalid system password");

        var sessionId = new SessionId(Guid.NewGuid());

        _persistenceContext.AdminSessions.Add(
            new AdminSession(sessionId));

        return new CreateAdminSessionOperation.Response.Success(sessionId.Value);
    }
}