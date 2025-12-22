using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class OperationHistoryRepository : IOperationHistoryRepository
{
    private readonly List<AccountTransaction> _transactions = new();

    public AccountTransaction Add(AccountTransaction accountTransaction)
    {
        _transactions.Add(accountTransaction);
        return accountTransaction;
    }

    public IEnumerable<AccountTransaction> Query(OperationHistoryQuery query)
    {
        return _transactions.Where(t => query.Ids.Contains(t.AccountId));
    }
}