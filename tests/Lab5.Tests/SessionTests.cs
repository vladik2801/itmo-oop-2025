using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Application.Services;
using Lab5.Infrastructure.Persistence;
using Lab5.Infrastructure.Persistence.Repositories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class SessionTests
{
    [Fact]
    public void When_AccountDoesNotExist_Should_ReturnFailure()
    {
        // Arrange
        PersistenceContext context = CreateContext();
        var service = new SessionService(context, "admin");
        var request = new CreateUserSessionOperation.Request(
            AccountId: 1,
            PinCode: 1234);

        // Act
        CreateUserSessionOperation.Response response = service.CreateUserSession(request);

        // Assert
        Assert.IsType<CreateUserSessionOperation.Response.Failure>(response);
    }

    [Fact]
    public void When_PinCodeIsInvalid_Should_ReturnFailure()
    {
        // Arrange
        PersistenceContext context = CreateContext();
        context.Accounts.Add(new Account(new AccountId(1), new PinCode(1111)));
        var service = new SessionService(context, "admin");
        var request = new CreateUserSessionOperation.Request(
            AccountId: 1,
            PinCode: 2222);

        // Act
        CreateUserSessionOperation.Response response = service.CreateUserSession(request);

        // Assert
        Assert.IsType<CreateUserSessionOperation.Response.Failure>(response);
    }

    [Fact]
    public void When_PinCodeIsCorrect_Should_ReturnSuccess()
    {
        // Arrange
        PersistenceContext context = CreateContext();
        context.Accounts.Add(new Account(new AccountId(1), new PinCode(1234)));
        var service = new SessionService(context, "admin");
        var request = new CreateUserSessionOperation.Request(
            AccountId: 1,
            PinCode: 1234);

        // Act
        CreateUserSessionOperation.Response response = service.CreateUserSession(request);

        // Assert
        Assert.IsType<CreateUserSessionOperation.Response.Success>(response);
    }

    [Fact]
    public void When_UserSessionIsCreated_Should_BeStoredInRepository()
    {
        // Arrange
        PersistenceContext context = CreateContext();
        context.Accounts.Add(new Account(new AccountId(1), new PinCode(1234)));
        var service = new SessionService(context, systemPassword: "admin");
        var request = new CreateUserSessionOperation.Request(AccountId: 1, PinCode: 1234);

        // Act
        CreateUserSessionOperation.Response response = service.CreateUserSession(request);

        // Assert
        CreateUserSessionOperation.Response.Success success =
            Assert.IsType<CreateUserSessionOperation.Response.Success>(response);
        UserSession? stored = context.UserSessions
            .Query(new UserSessionQuery(new[] { new SessionId(success.SessionId) }))
            .FirstOrDefault();
        Assert.NotNull(stored);
    }

    [Fact]
    public void When_SystemPasswordIsWrong_Should_ReturnFailure()
    {
        // Arrange
        PersistenceContext context = CreateContext();
        var service = new SessionService(context, "admin");
        var request = new CreateAdminSessionOperation.Request("wrong");

        // Act
        CreateAdminSessionOperation.Response response = service.CreateAdminSession(request);

        // Assert
        Assert.IsType<CreateAdminSessionOperation.Response.Failure>(response);
    }

    [Fact]
    public void When_SystemPasswordIsCorrect_Should_ReturnSuccess()
    {
        // Arrange
        PersistenceContext context = CreateContext();
        var service = new SessionService(context, "admin");
        var request = new CreateAdminSessionOperation.Request("admin");

        // Act
        CreateAdminSessionOperation.Response response = service.CreateAdminSession(request);

        // Assert
        Assert.IsType<CreateAdminSessionOperation.Response.Success>(response);
    }

    [Fact]
    public void When_CreatingMultipleUserSessions_Should_CreateDifferentIds()
    {
        // Arrange
        PersistenceContext context = CreateContext();
        context.Accounts.Add(new Account(new AccountId(1), new PinCode(1234)));
        var service = new SessionService(context, "admin");
        var request = new CreateUserSessionOperation.Request(1, 1234);

        // Act
        var r1 = (CreateUserSessionOperation.Response.Success)service.CreateUserSession(request);
        var r2 = (CreateUserSessionOperation.Response.Success)service.CreateUserSession(request);

        // Assert
        Assert.NotEqual(r1.SessionId, r2.SessionId);
    }

    private static PersistenceContext CreateContext()
    {
        return new PersistenceContext(
            new AccountRepository(),
            new UserSessionRepository(),
            new AdminSessionRepository(),
            new OperationHistoryRepository());
    }
}