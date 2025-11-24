using Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public sealed class FormatterMock : IMessageFormatter
{
    private readonly string? _expectedTitle;

    private readonly string? _expectedBody;

    private string? _title;

    private string? _body;

    public FormatterMock(string expectedTitle, string expectedBody)
    {
        _expectedTitle = expectedTitle;
        _expectedBody = expectedBody;
    }

    public void WriteTitleMessage(string title)
    {
        _title = title;
    }

    public void WriteBodyMessage(string body)
    {
        _body = body;
    }

    public void Verify()
    {
        Assert.Equal(_expectedTitle, _title);
        Assert.Equal(_expectedBody, _body);
    }
}