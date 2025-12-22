using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Lab5.Application.Abstractions.Persistence.Queries;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface IAdminSessionRepository
{
    AdminSession Add(AdminSession adminSession);

    IEnumerable<AdminSession> Query(AdminSessionQuery query);
}