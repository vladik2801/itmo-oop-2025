using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Mocks;

public sealed class FileOutputModeMock : IFileOutputMode
{
    public FileOutputModeMock(string mode)
    {
        Mode = mode;
    }

    public string Mode { get; }

    public string? LastPath { get; private set; }

    public string? LastText { get; private set; }

    public void Show(string filePath, string context)
    {
        LastPath = filePath;
        LastText = context;
    }
}