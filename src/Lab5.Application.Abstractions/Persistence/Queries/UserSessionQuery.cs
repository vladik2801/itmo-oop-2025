using Itmo.ObjectOrientedProgramming.Lab5.Sessions;

namespace Lab5.Application.Abstractions.Persistence.Queries;

public sealed record UserSessionQuery(SessionId[] Ids);