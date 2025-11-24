using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Archiving;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class FormattingTests
{
    [Fact]
    public void Archive_ShouldCallFormatter()
    {
        // Arrange
        var formatter = new FormatterMock(new("t"), new("b"));
        var sut = new FormattingArchiver(formatter);

        // Act
        sut.Archive(new Message(new("t"), new("b"), Priority.Medium));

        // Assert
        formatter.Verify();
    }
}