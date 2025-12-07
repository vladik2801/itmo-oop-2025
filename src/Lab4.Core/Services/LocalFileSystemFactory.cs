using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Services;

public class LocalFileSystemFactory : IFileSystemFactory
{
    public IFileSystem Create(string path)
    {
        return new LocalFileSystem(path);
    }
}