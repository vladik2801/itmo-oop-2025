using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;
using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Services;
using Lab5.Infrastructure.Persistence;
using Lab5.Infrastructure.Persistence.Repositories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public sealed class AccountServiceTests
{
    [Fact]
    public void When_WithdrawWithEnoughMoney_Should_ReturnSuccess_AndDecreaseBalance()
    {
        // Arrange
        PersistenceContext context = CreateContext();
        context.Accounts.Add(new Account(new AccountId(1), new PinCode(1234)));
        Guid sessionId = CreateUserSession(context, accountId: 1, pinCode: 1234);
        var service = new AccountService(context);
        var deposit = new DepositOperation.Request(sessionId, 200);
        service.Deposit(deposit);
        var withdraw = new WithdrawOperation.Request(sessionId, 50);

        // Act
        WithdrawOperation.Response response = service.Withdraw(withdraw);

        // Assert
        Assert.IsType<WithdrawOperation.Response.Success>(response);
        AccountBalanceModel balance = service.GetBalance(sessionId);
        Assert.Equal(150, balance.Balance);
    }

    [Fact]
    public void When_DepositWithPositiveAmount_Should_ReturnSuccess_AndIncreaseBalance()
    {
        // Arrange
        PersistenceContext context = CreateContext();
        context.Accounts.Add(new Account(new AccountId(1), new PinCode(1234)));
        Guid sessionId = CreateUserSession(context, accountId: 1, pinCode: 1234);
        var service = new AccountService(context);
        var request = new DepositOperation.Request(
            SessionId: sessionId,
            Amount: 100);

        // Act
        DepositOperation.Response response = service.Deposit(request);

        // Assert
        Assert.IsType<DepositOperation.Response.Success>(response);
        AccountBalanceModel balance = service.GetBalance(sessionId);
        Assert.Equal(100, balance.Balance);
    }

    [Fact]
    public void When_DepositThenWithdraw_Should_KeepConsistentBalance()
    {
        // Arrange
        PersistenceContext context = CreateContext();
        context.Accounts.Add(new Account(new AccountId(1), new PinCode(1234)));
        Guid sessionId = CreateUserSession(context, accountId: 1, pinCode: 1234);
        var service = new AccountService(context);

        // Act
        service.Deposit(new DepositOperation.Request(sessionId, 300));
        service.Withdraw(new WithdrawOperation.Request(sessionId, 120));
        service.Deposit(new DepositOperation.Request(sessionId, 50));
        service.Withdraw(new WithdrawOperation.Request(sessionId, 10));

        // Assert
        AccountBalanceModel balance = service.GetBalance(sessionId);
        Assert.Equal(220, balance.Balance);
    }

    private static PersistenceContext CreateContext()
    {
        return new PersistenceContext(
            new AccountRepository(),
            new UserSessionRepository(),
            new AdminSessionRepository(),
            new OperationHistoryRepository());
    }

    private static Guid CreateUserSession(PersistenceContext context, long accountId, int pinCode)
    {
        var sessionId = new SessionId(Guid.NewGuid());
        var session = new UserSession(sessionId, new AccountId(accountId));
        context.UserSessions.Add(session);
        return sessionId.Value;
    }
}