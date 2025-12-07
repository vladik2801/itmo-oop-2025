using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

public class LocalConnectionModeStrategy : IConnectionModeStrategy
{
    private readonly IFileSystemFactory _fileSystemFactory;

    public LocalConnectionModeStrategy(IFileSystemFactory fileSystemFactory)
    {
        _fileSystemFactory = fileSystemFactory;
    }

    public string Mode => "local";

    public IFileSystem CreateFileSystem(string path)
    {
        return _fileSystemFactory.Create(path);
    }
}