using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Lab5.Application.Abstractions.Persistence.Queries;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface IUserSessionRepository
{
    UserSession Add(UserSession userSession);

    IEnumerable<UserSession> Query(UserSessionQuery query);
}