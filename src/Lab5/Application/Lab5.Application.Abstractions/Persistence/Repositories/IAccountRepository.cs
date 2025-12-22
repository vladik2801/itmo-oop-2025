using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Lab5.Application.Abstractions.Persistence.Queries;

namespace Lab5.Application.Abstractions.Persistence.Repositories;

public interface IAccountRepository
{
    Account Add(Account account);

    void Update(Account account);

    IEnumerable<Account> Query(AccountQuery query);
}