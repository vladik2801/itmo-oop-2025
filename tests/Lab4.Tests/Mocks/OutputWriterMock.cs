using Itmo.ObjectOrientedProgramming.Lab4.Core;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Mocks;

public sealed class OutputWriterMock : IOutputWriter
{
    public string WrittenText { get; private set; } = string.Empty;

    public void Write(string text)
    {
        WrittenText += text;
    }
}