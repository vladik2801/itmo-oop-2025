using Itmo.ObjectOrientedProgramming.Lab2.Domain;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class UserInboxTests
{
    [Fact]
    public void MarkRead_ShouldCreateUnreadEntry()
    {
        // Arrange
        var user = new User(new("Vlad"));
        var message = new Message(new("t"), new("b"), Priority.Medium);

        // Act
        user.Receive(message);
        Result fisrt = user.MakeRead(message);

        // Assert
        Assert.IsType<Result.Succes>(fisrt);
    }

    [Fact]
    public void MarkRead_Twice_ShouldThrow()
    {
        // Arrange
        var user = new User(new("Vlad"));
        var message = new Message(new("t"), new("b"), Priority.Medium);

        // Act
        user.Receive(message);
        Result fisrt = user.MakeRead(message);
        Result second = user.MakeRead(message);

        // Assert
        Assert.IsType<Result.Succes>(fisrt);
        Assert.IsType<Result.AlreadyRead>(second);
    }

    [Fact]
    public void MarkRead_WhenMessageNotSend_ShouldReturnNotFount()
    {
        // Arrange
        var user = new User(new("Vlad"));
        var unknownMessage = new Message(new("t"), new("b"), Priority.Medium);

        // Act
        Result result = user.MakeRead(unknownMessage);

        // Assert
        Assert.IsType<Result.NotFound>(result);
    }
}