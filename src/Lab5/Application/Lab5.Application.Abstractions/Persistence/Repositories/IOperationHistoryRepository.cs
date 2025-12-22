using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Lab5.Application.Abstractions.Persistence.Queries;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface IOperationHistoryRepository
{
    AccountTransaction Add(AccountTransaction accountTransaction);

    IEnumerable<AccountTransaction> Query(OperationHistoryQuery query);
}