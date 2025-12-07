using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

public interface IFileSystemEntityVisitor
{
    void Visit(FileEntity file);

    void Visit(DirectoryEntity directory);
}