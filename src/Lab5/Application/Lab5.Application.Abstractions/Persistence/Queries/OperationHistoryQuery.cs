using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;

namespace Lab5.Application.Abstractions.Persistence.Queries;

public sealed record OperationHistoryQuery(AccountId[] Ids);