using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Mocks;

public sealed class ConnectionModeStrategyMock : IConnectionModeStrategy
{
    public ConnectionModeStrategyMock(string mode)
    {
        Mode = mode;
    }

    public string Mode { get; }

    public string? LastPath { get; private set; }

    public IFileSystem? LastFileSystem { get; private set; }

    public IFileSystem CreateFileSystem(string path)
    {
        LastPath = path;
        FileSystemMock fs = new();
        LastFileSystem = fs;
        return fs;
    }
}