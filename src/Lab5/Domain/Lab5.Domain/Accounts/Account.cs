using Itmo.ObjectOrientedProgramming.Lab5.Results;
using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Accounts;

public sealed class Account
{
    public Account(AccountId id, PinCode pinCode)
    {
        Id = id;
        PinCode = pinCode;
        Balance = new(0);
    }

    public AccountId Id { get; }

    public PinCode PinCode { get; }

    public Money Balance { get; private set; }

    public DepositResult Deposit(Money amount)
    {
        if (amount.Value <= 0)
            return new DepositResult.Failure("Amount must be positive");
        Balance = Balance.Add(amount);
        return new DepositResult.Success(Balance);
    }

    public WithdrawResult Withdraw(Money amount)
    {
        if (amount.Value <= 0)
            return new WithdrawResult.Failure("Amount must be positive");

        if (Balance.Value < amount.Value)
            return new WithdrawResult.Failure("Insufficient funds");
        Balance = Balance.Subtract(amount);
        return new WithdrawResult.Success(Balance);
    }
}