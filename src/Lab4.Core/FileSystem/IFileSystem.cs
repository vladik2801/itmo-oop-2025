namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystem
{
    DirectoryEntity Root { get; }

    IEnumerable<IFileSystemEntity> EnumerateChildren(DirectoryEntity directory);

    string ListTree(string currentPath, int maxDepth);

    string ReadFile(string path);

    OperationResult MoveFile(string sourcePath, string destDirectoryPath);

    OperationResult CopyFile(string sourcePath, string destDirectoryPath);

    OperationResult DeleteFile(string path);

    OperationResult RenameFile(string sourcePath, string newName);
}