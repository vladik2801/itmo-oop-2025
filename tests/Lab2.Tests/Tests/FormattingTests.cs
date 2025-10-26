using Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Archiving;
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

    [Fact]
    public void ShouldWriteInExpectedOrder()
    {
        var output = new OutputMock();

        output.ExpectWriteln("# Title");
        output.ExpectWriteln(string.Empty);
        output.ExpectWriteln("Body");
        output.ExpectWriteln(string.Empty);
        output.ExpectWriteln("> Priority: High");

        var sut = new MarkDownMessageFormatter(output);
        var message = new Message("Title", "Body", Priority.High);

        sut.Format(message);

        output.Verify();
    }
}