using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Logging;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public sealed class LoggerMock : ILogger
{
    private readonly int _expectedCalls;

    private int _calls;

    public LoggerMock(int expectedCalls)
    {
        _expectedCalls = expectedCalls;
    }

    public void Log(string text)
    {
        _calls++;
    }

    public void Verify() => Assert.Equal(_expectedCalls, _calls);
}