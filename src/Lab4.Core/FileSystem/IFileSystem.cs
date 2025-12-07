namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystem
{
    DirectoryEntity Root { get; }

    IEnumerable<IFileSystemEntity> EnumerateChildren(DirectoryEntity directory);

    DirectoryEntity? GetDirectoryByPath(string path);

    string ReadFile(string path);

    OperationResult MoveFile(string sourcePath, string destDirectoryPath);

    OperationResult CopyFile(string sourcePath, string destDirectoryPath);

    OperationResult DeleteFile(string path);

    OperationResult RenameFile(string sourcePath, string newName);
}