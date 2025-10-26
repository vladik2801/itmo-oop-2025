using Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public sealed class FormatterMock : IMessageFormatter
{
    private int _calls;

    public int ExpectedCalls { get; set; } = 1;

    public void Format(Message message) => _calls++;

    public void Verify() => Assert.Equal(ExpectedCalls, _calls);
}