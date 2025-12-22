using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public sealed class MockOperationHistoryRepository : IOperationHistoryRepository
{
    private readonly List<AccountTransaction> _storage = new List<AccountTransaction>();

    public int AddCalls { get; private set; }

    public IReadOnlyList<AccountTransaction> Stored => _storage;

    public IEnumerable<AccountTransaction> Query(OperationHistoryQuery query)
    {
        HashSet<AccountId> ids = query.Ids.ToHashSet();
        return _storage.Where(t => ids.Contains(t.AccountId));
    }

    public AccountTransaction Add(AccountTransaction accountTransaction)
    {
        AddCalls++;
        _storage.Add(accountTransaction);
        return accountTransaction;
    }
}