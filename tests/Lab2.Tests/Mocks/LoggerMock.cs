using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Logging;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public sealed class LoggerMock : ILogger
{
    private int _calls;

    public int ExpectedCalls { get; set; } = 1;

    public string? ExpectedSubstring { get; set; }

    public void Info(string text) => Log(text);

    public void Warn(string text) => Log(text);

    public void LogError(string text, Exception? ex = null) => Log(text);

    public void Log(string text)
    {
        _calls++;
        if (ExpectedSubstring is not null && !text.Contains(ExpectedSubstring, StringComparison.OrdinalIgnoreCase))
        {
            throw new Xunit.Sdk.XunitException($"Лог не содержит: {ExpectedSubstring}");
        }
    }

    public void Verify() => Assert.Equal(ExpectedCalls, _calls);
}