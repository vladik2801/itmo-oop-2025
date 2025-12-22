using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;
using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Application.Options;
using Lab5.Application.Services;
using Microsoft.Extensions.Options;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public sealed class SessionTests
{
    [Fact]
    public void When_CreateUserSession_AndAccountNotFound_Should_ReturnFailure()
    {
        // Arrange
        var accounts = new MockAccountRepository();
        var userSessions = new MockUserSessionRepository();
        var adminSessions = new MockAdminSessionRepository();
        var history = new MockOperationHistoryRepository();
        var context = new MockPersistenceContext(accounts, userSessions, adminSessions, history);
        IOptions<AdminOptions> options = Options.Create(new AdminOptions { SystemPassword = "admin" });
        var service = new SessionService(context, options);
        var request = new CreateUserSessionOperation.Request(AccountId: 1, PinCode: 1234);

        // Act
        CreateUserSessionOperation.Response response = service.CreateUserSession(request);

        // Assert
        Assert.IsType<CreateUserSessionOperation.Response.Failure>(response);
    }

    [Fact]
    public void When_CreateUserSession_AndPinIsWrong_Should_ReturnFailure()
    {
        // Arrange
        var accounts = new MockAccountRepository();
        accounts.Seed(new Account(new AccountId(1), new PinCode(1111)));
        var userSessions = new MockUserSessionRepository();
        var adminSessions = new MockAdminSessionRepository();
        var history = new MockOperationHistoryRepository();
        var context = new MockPersistenceContext(accounts, userSessions, adminSessions, history);
        IOptions<AdminOptions> options = Options.Create(new AdminOptions { SystemPassword = "admin" });
        var service = new SessionService(context, options);
        var request = new CreateUserSessionOperation.Request(AccountId: 1, PinCode: 2222);

        // Act
        CreateUserSessionOperation.Response response = service.CreateUserSession(request);

        // Assert
        Assert.IsType<CreateUserSessionOperation.Response.Failure>(response);
    }

    [Fact]
    public void When_CreateUserSession_Success_Should_StoreSession()
    {
        // Arrange
        var accounts = new MockAccountRepository();
        accounts.Seed(new Account(new AccountId(1), new PinCode(1234)));
        var userSessions = new MockUserSessionRepository();
        var adminSessions = new MockAdminSessionRepository();
        var history = new MockOperationHistoryRepository();
        var context = new MockPersistenceContext(accounts, userSessions, adminSessions, history);
        IOptions<AdminOptions> options = Options.Create(new AdminOptions { SystemPassword = "admin" });
        var service = new SessionService(context, options);
        var request = new CreateUserSessionOperation.Request(AccountId: 1, PinCode: 1234);

        // Act
        CreateUserSessionOperation.Response response = service.CreateUserSession(request);

        // Assert
        Assert.IsType<CreateUserSessionOperation.Response.Success>(response);
        Assert.Equal(1, userSessions.AddCalls);
    }

    [Fact]
    public void When_CreateAdminSession_AndPasswordWrong_Should_ReturnFailure()
    {
        // Arrange
        var accounts = new MockAccountRepository();
        var userSessions = new MockUserSessionRepository();
        var adminSessions = new MockAdminSessionRepository();
        var history = new MockOperationHistoryRepository();
        var context = new MockPersistenceContext(accounts, userSessions, adminSessions, history);
        IOptions<AdminOptions> options = Options.Create(new AdminOptions { SystemPassword = "admin" });
        var service = new SessionService(context, options);
        var request = new CreateAdminSessionOperation.Request(SystemPassword: "wrong");

        // Act
        CreateAdminSessionOperation.Response response = service.CreateAdminSession(request);

        // Assert
        Assert.IsType<CreateAdminSessionOperation.Response.Failure>(response);
    }

    [Fact]
    public void When_CreateAdminSession_Success_Should_StoreSession()
    {
        // Arrange
        var accounts = new MockAccountRepository();
        var userSessions = new MockUserSessionRepository();
        var adminSessions = new MockAdminSessionRepository();
        var history = new MockOperationHistoryRepository();
        var context = new MockPersistenceContext(accounts, userSessions, adminSessions, history);
        IOptions<AdminOptions> options = Options.Create(new AdminOptions { SystemPassword = "admin" });
        var service = new SessionService(context, options);
        var request = new CreateAdminSessionOperation.Request(SystemPassword: "admin");

        // Act
        CreateAdminSessionOperation.Response response = service.CreateAdminSession(request);

        // Assert
        Assert.IsType<CreateAdminSessionOperation.Response.Success>(response);
        Assert.Equal(1, adminSessions.AddCalls);
    }
}