using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Archiving;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class FormattingTests
{
    [Fact]
    public void Archive_ShouldCallFormatter()
    {
        var formatter = new FormatterMock { ExpectedCalls = 1 };
        var sut = new FormattingArchiver(formatter);

        sut.Archive(new Message("t", "b", Priority.Medium));

        formatter.Verify();
    }
}