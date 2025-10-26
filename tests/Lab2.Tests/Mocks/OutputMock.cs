using Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public class OutputMock : IOutput
{
    private readonly Queue<string> _expected = new();

    public void ExpectWriteln(string message) => _expected.Enqueue("W: " + message);

    public void Writeln(string message)
    {
        if (_expected.Count == 0 || _expected.Dequeue() != "W: " + message)
            throw new Xunit.Sdk.XunitException("Неожиданный Writeln вызов");
    }

    public void Verify() => Assert.Empty(_expected);
}