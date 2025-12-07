using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystemEntity
{
    string Path { get; }

    void Accept(IFileSystemEntityVisitor visitor);
}