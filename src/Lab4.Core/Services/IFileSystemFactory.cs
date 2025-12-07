using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Services;

public interface IFileSystemFactory
{
    IFileSystem Create(string path);
}