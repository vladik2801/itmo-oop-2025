using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Lab5.Application.Contracts.Sessions.Models;

namespace Lab5.Application.Mapping;

public static class SessionMappingExtensions
{
    public static SessionModel MapToModel(this SessionId sessionId)
        => new SessionModel(sessionId.Value);
}