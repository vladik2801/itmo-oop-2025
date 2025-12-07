using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

public interface IConnectionModeStrategy
{
    string Mode { get; }

    IFileSystem CreateFileSystem(string path);
}