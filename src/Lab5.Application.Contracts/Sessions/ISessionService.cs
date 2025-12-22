using Lab5.Application.Contracts.Sessions.Operations;

namespace Lab5.Application.Contracts.Sessions;

public interface ISessionService
{
    CreateUserSessionOperation.Response CreateUserSession(CreateUserSessionOperation.Request request);

    CreateAdminSessionOperation.Response CreateAdminSession(CreateAdminSessionOperation.Request request);
}