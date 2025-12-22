using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Abstractions.Persistence.Repositories;

namespace Lab5.Infrastructure.Persistence.Repositories;

public sealed class AccountRepository : IAccountRepository
{
    private readonly Dictionary<AccountId, Account> _accounts = new();

    public Account Add(Account account)
    {
        _accounts[account.Id] = account;
        return account;
    }

    public void Update(Account account)
    {
        _accounts[account.Id] = account;
    }

    public IEnumerable<Account> Query(AccountQuery query)
    {
        return _accounts
            .Where(pair => query.Ids.Contains(pair.Key))
            .Select(pair => pair.Value);
    }
}