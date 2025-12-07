using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public sealed class Session
{
    public IFileSystem? FileSystem { get; private set; }

    public string? LocalPath { get; set; }

    public void Connect(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
        LocalPath = "/";
    }

    public void Disconnect()
    {
        FileSystem = null;
        LocalPath = "/";
    }
}