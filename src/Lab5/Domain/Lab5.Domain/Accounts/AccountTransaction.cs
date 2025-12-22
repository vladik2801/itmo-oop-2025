using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Accounts;

public sealed class AccountTransaction
{
    public AccountTransaction(TransactionType transactionType, Money amount, AccountId accountId)
    {
        TransactionType = transactionType;
        Amount = amount;
        AccountId = accountId;
    }

    public TransactionType TransactionType { get; }

    public Money Amount { get; }

    public AccountId AccountId { get; }
}