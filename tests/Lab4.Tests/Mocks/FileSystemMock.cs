using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.Mocks;

public class FileSystemMock : IFileSystem
{
    public FileSystemMock()
    {
        Root = new DirectoryEntity("/");
    }

    public DirectoryEntity Root { get; }

    public DirectoryEntity? Directory { get; set; }

    public bool MoveCalled { get; private set; }

    public string? MoveSource { get; private set; }

    public string? MoveDestination { get; private set; }

    public bool CopyCalled { get; private set; }

    public string? CopySource { get; private set; }

    public string? CopyDestination { get; private set; }

    public bool DeleteCalled { get; private set; }

    public string? DeletePath { get; private set; }

    public bool RenameCalled { get; private set; }

    public string? RenamePath { get; private set; }

    public string? RenameName { get; private set; }

    public IEnumerable<IFileSystemEntity> EnumerateChildren(DirectoryEntity directory)
    {
        return directory.Children;
    }

    public DirectoryEntity? GetDirectoryByPath(string path)
    {
        return Directory;
    }

    public string ReadFile(string path)
    {
        return "CONTENT" + path;
    }

    public OperationResult MoveFile(string sourcePath, string destDirectoryPath)
    {
        MoveCalled = true;
        MoveSource = sourcePath;
        MoveDestination = destDirectoryPath;
        return new OperationResult.Succes();
    }

    public OperationResult CopyFile(string sourcePath, string destDirectoryPath)
    {
        CopyCalled = true;
        CopySource = sourcePath;
        CopyDestination = destDirectoryPath;
        return new OperationResult.Succes();
    }

    public OperationResult DeleteFile(string path)
    {
        DeleteCalled = true;
        DeletePath = path;
        return new OperationResult.Succes();
    }

    public OperationResult RenameFile(string sourcePath, string newName)
    {
        RenameCalled = true;
        RenamePath = sourcePath;
        RenameName = newName;
        return new OperationResult.Succes();
    }
}