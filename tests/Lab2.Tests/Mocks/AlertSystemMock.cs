using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Alerts;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public sealed class AlertSystemMock : IAlertSystem
{
    private int _calls;

    public int ExpectedCalls { get; set; } = 1;

    public void Notify(Message message, string reason) => _calls++;

    public void Verify() => Assert.Equal(ExpectedCalls, _calls);
}