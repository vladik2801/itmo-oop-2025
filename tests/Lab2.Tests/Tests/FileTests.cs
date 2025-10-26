using Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Archiving;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Decorators;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Logging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class FileTests
{
    [Fact]
    public void LoggingRecipient_WithFileLogger_WritesTwoLines()
    {
        string dir = Path.Combine(Path.GetTempPath(), "lab2_logs");
        Directory.CreateDirectory(dir);
        string path = Path.Combine(dir, Guid.NewGuid().ToString() + ".log");

        var inner = new RecipientMock { ExceptedCalls = 1 };

        using (var filelogger = new FileLogger(path))
        {
            var sut = new LoggingRecipients(inner, filelogger);
            sut.Send(new Message("Title", "Body", Priority.High));
        }

        string[] lines = File.ReadAllLines(path);
        Assert.True(lines.Length >= 2, "Expected at least 2 lines");
    }

    [Fact]
    public void FormattingArchiver_WritesMarkdown_ToGivenFile()
    {
        string dir = Path.Combine(Path.GetTempPath(), "lab2_archive");
        Directory.CreateDirectory(dir);
        string path = Path.Combine(dir, Guid.NewGuid() + ".md");

        using (var output = new FileOutput(path))
        {
            var formatter = new MarkDownMessageFormatter(output);
            var archiver = new FormattingArchiver(formatter);

            var message = new Message("Title", "Body", Priority.High);
            archiver.Archive(message);
        }

        string text = File.ReadAllText(path);
        Assert.Contains("# Title", text, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("Body", text, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("Priority", text, StringComparison.OrdinalIgnoreCase);
    }
}