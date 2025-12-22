using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public sealed class MockAccountRepository : IAccountRepository
{
    private readonly Dictionary<AccountId, Account> _storage = new Dictionary<AccountId, Account>();

    public int AddCalls { get; private set; }

    public int UpdateCalls { get; private set; }

    public void Seed(Account account)
    {
        _storage[account.Id] = account;
    }

    public IEnumerable<Account> Query(AccountQuery query)
    {
        return query.Ids
            .Where(id => _storage.ContainsKey(id))
            .Select(id => _storage[id]);
    }

    public Account Add(Account account)
    {
        AddCalls++;
        _storage[account.Id] = account;
        return account;
    }

    public void Update(Account account)
    {
        UpdateCalls++;
        _storage[account.Id] = account;
    }
}