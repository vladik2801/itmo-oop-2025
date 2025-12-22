using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;
using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;
using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public sealed class AccountServiceTests
{
    [Fact]
    public void When_Deposit_AndSessionNotFound_Should_ReturnFailure()
    {
        // Arrange
        var accounts = new MockAccountRepository();
        var userSessions = new MockUserSessionRepository();
        var adminSessions = new MockAdminSessionRepository();
        var history = new MockOperationHistoryRepository();
        var context = new MockPersistenceContext(accounts, userSessions, adminSessions, history);
        var service = new AccountService(context);
        var request = new DepositOperation.Request(SessionId: Guid.NewGuid(), Amount: 100);

        // Act
        DepositOperation.Response response = service.Deposit(request);

        // Assert
        Assert.IsType<DepositOperation.Response.Failure>(response);
    }

    [Fact]
    public void When_Deposit_WithNonPositiveAmount_Should_ReturnFailure()
    {
        // Arrange
        var accounts = new MockAccountRepository();
        accounts.Seed(new Account(new AccountId(1), new PinCode(1234)));
        var userSessions = new MockUserSessionRepository();
        var sessionId = new SessionId(Guid.NewGuid());
        userSessions.Seed(new UserSession(sessionId, new AccountId(1)));
        var adminSessions = new MockAdminSessionRepository();
        var history = new MockOperationHistoryRepository();
        var context = new MockPersistenceContext(accounts, userSessions, adminSessions, history);
        var service = new AccountService(context);
        var request = new DepositOperation.Request(SessionId: sessionId.Value, Amount: 0);

        // Act
        DepositOperation.Response response = service.Deposit(request);

        // Assert
        Assert.IsType<DepositOperation.Response.Failure>(response);
    }

    [Fact]
    public void When_Deposit_Success_Should_IncreaseBalance_AndWriteHistory()
    {
        // Arrange
        var accounts = new MockAccountRepository();
        accounts.Seed(new Account(new AccountId(1), new PinCode(1234)));
        var userSessions = new MockUserSessionRepository();
        var sessionId = new SessionId(Guid.NewGuid());
        userSessions.Seed(new UserSession(sessionId, new AccountId(1)));
        var adminSessions = new MockAdminSessionRepository();
        var history = new MockOperationHistoryRepository();
        var context = new MockPersistenceContext(accounts, userSessions, adminSessions, history);
        var service = new AccountService(context);
        var request = new DepositOperation.Request(SessionId: sessionId.Value, Amount: 100);

        // Act
        DepositOperation.Response response = service.Deposit(request);

        // Assert
        Assert.IsType<DepositOperation.Response.Success>(response);
        AccountBalanceModel balance = service.GetBalance(sessionId.Value);
        Assert.Equal(100m, balance.Balance);
        Assert.Equal(1, history.AddCalls);
    }

    [Fact]
    public void When_Withdraw_AndInsufficientFunds_Should_ReturnFailure_AndNotWriteHistory()
    {
        // Arrange
        var accounts = new MockAccountRepository();
        accounts.Seed(new Account(new AccountId(1), new PinCode(1234)));
        var userSessions = new MockUserSessionRepository();
        var sessionId = new SessionId(Guid.NewGuid());
        userSessions.Seed(new UserSession(sessionId, new AccountId(1)));
        var adminSessions = new MockAdminSessionRepository();
        var history = new MockOperationHistoryRepository();
        var context = new MockPersistenceContext(accounts, userSessions, adminSessions, history);
        var service = new AccountService(context);
        var request = new WithdrawOperation.Request(SessionId: sessionId.Value, Amount: 50);

        // Act
        WithdrawOperation.Response response = service.Withdraw(request);

        // Assert
        Assert.IsType<WithdrawOperation.Response.Failure>(response);
        Assert.Equal(0, history.AddCalls);
    }

    [Fact]
    public void When_Withdraw_Success_Should_DecreaseBalance_AndWriteHistory()
    {
        // Arrange
        var accounts = new MockAccountRepository();
        accounts.Seed(new Account(new AccountId(1), new PinCode(1234)));
        var userSessions = new MockUserSessionRepository();
        var sessionId = new SessionId(Guid.NewGuid());
        userSessions.Seed(new UserSession(sessionId, new AccountId(1)));
        var adminSessions = new MockAdminSessionRepository();
        var history = new MockOperationHistoryRepository();
        var context = new MockPersistenceContext(accounts, userSessions, adminSessions, history);
        var service = new AccountService(context);
        service.Deposit(new DepositOperation.Request(sessionId.Value, 200));
        var request = new WithdrawOperation.Request(SessionId: sessionId.Value, Amount: 50);

        // Act
        WithdrawOperation.Response response = service.Withdraw(request);

        // Assert
        Assert.IsType<WithdrawOperation.Response.Success>(response);

        AccountBalanceModel balance = service.GetBalance(sessionId.Value);
        Assert.Equal(150, balance.Balance);

        Assert.Equal(2, history.AddCalls);
    }
}