using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class BaseTests
{
    [Fact]
    public void ConnectCommand_WithAbsolutePath_ConnectsSession()
    {
        // Arrange
        FileSystemContext context = new(new UnixPathService());
        FileSystemMock fs = new();
        ConnectCommand command = new(fs, "/");

        // Act
        OperationResult result = command.Execute(context);

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.NotNull(context.FileSystem);
        Assert.Equal("/", context.CurrentPath);
    }

    [Fact]
    public void DisconnectCommand_WhenNotConnected_ReturnsFailure()
    {
        // Arrange
        FileSystemContext context = new(new UnixPathService());
        DisconnectCommand command = new();

        // Act
        OperationResult result = command.Execute(context);

        // Assert
        OperationResult.Failure failure = Assert.IsType<OperationResult.Failure>(result);
        Assert.False(string.IsNullOrWhiteSpace(failure.Message));
        Assert.Null(context.FileSystem);
    }

    [Fact]
    public void DisconnectCommand_WhenConnected_ClearsFileSystem()
    {
        // Arrange
        FileSystemContext context = new(new UnixPathService());
        FileSystemMock fs = new();
        context.FileSystem = fs;
        context.CurrentPath = "/somewhere";
        DisconnectCommand command = new();

        // Act
        OperationResult result = command.Execute(context);

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.Null(context.FileSystem);
        Assert.Equal("/", context.CurrentPath);
    }

    [Fact]
    public void TreeListCommand_WhenNotConnected_ReturnsNotConnected()
    {
        // Arrange
        FileSystemContext context = new(new UnixPathService());
        OutputWriterMock writer = new();
        TreeListCommand command = new(2, writer);

        // Act
        OperationResult result = command.Execute(context);

        // Assert
        OperationResult.Failure failure = Assert.IsType<OperationResult.Failure>(result);
        Assert.Equal("Not connected", failure.Message);
        Assert.Equal(string.Empty, writer.WrittenText);
    }

    [Fact]
    public void TreeListCommand_WithValidRootDirectory_WritesTree()
    {
        // Arrange
        FileSystemContext context = new(new UnixPathService());
        FileSystemMock fs = new();
        DirectoryEntity root = new("/");
        fs.Directory = root;
        context.FileSystem = fs;
        context.CurrentPath = "/";
        OutputWriterMock writer = new();
        TreeListCommand command = new(1, writer);

        // Act
        OperationResult result = command.Execute(context);

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.Contains('/', writer.WrittenText);
    }

    [Fact]
    public void TreeListCommand_WhenDirectoryNotFound_ReturnsFailure()
    {
        // Arrange
        FileSystemContext context = new(new UnixPathService());
        FileSystemMock fs = new();
        fs.Directory = null;
        context.FileSystem = fs;
        context.CurrentPath = "/unknown";
        OutputWriterMock writer = new();
        TreeListCommand command = new(1, writer);

        // Act
        OperationResult result = command.Execute(context);

        // Assert
        OperationResult.Failure failure = Assert.IsType<OperationResult.Failure>(result);
        Assert.Equal("Directory not found", failure.Message);
    }

    [Fact]
    public void FileMoveCommand_WhenConnected_CallsFileSystemMoveFile()
    {
        // Arrange
        FileSystemContext context = new(new UnixPathService());
        FileSystemMock fs = new();
        context.FileSystem = fs;
        context.CurrentPath = "/";
        FileMoveCommand command = new("/src.txt", "/destDir");

        // Act
        OperationResult result = command.Execute(context);

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.True(fs.MoveCalled);
        Assert.Equal("/src.txt", fs.MoveSource);
        Assert.Equal("/destDir", fs.MoveDestination);
    }

    [Fact]
    public void FileDeleteCommand_WhenConnected_CallsFileSystemDeleteFile()
    {
        // Arrange
        FileSystemContext context = new(new UnixPathService());
        FileSystemMock fs = new();
        context.FileSystem = fs;
        context.CurrentPath = "/";
        FileDeleteCommand command = new("/toDelete.txt");

        // Act
        OperationResult result = command.Execute(context);

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.True(fs.DeleteCalled);
        Assert.Equal("/toDelete.txt", fs.DeletePath);
    }

    [Fact]
    public void FileRenameCommand_WhenConnected_CallsFileSystemRenameFile()
    {
        // Arrange
        FileSystemContext context = new(new UnixPathService());
        FileSystemMock fs = new();
        context.FileSystem = fs;
        context.CurrentPath = "/";
        FileRenameCommand command = new("/old.txt", "new.txt");

        // Act
        OperationResult result = command.Execute(context);

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.True(fs.RenameCalled);
        Assert.Equal("/old.txt", fs.RenamePath);
        Assert.Equal("new.txt", fs.RenameName);
    }

    [Fact]
    public void FileCopyCommand_WhenConnected_CallsFileSystemCopyFile()
    {
        // Arrange
        FileSystemContext context = new(new UnixPathService());
        FileSystemMock fs = new();
        context.FileSystem = fs;
        context.CurrentPath = "/";
        FileCopyCommand command = new("/a.txt", "/dir");

        // Act
        OperationResult result = command.Execute(context);

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.True(fs.CopyCalled);
        Assert.Equal("/a.txt", fs.CopySource);
        Assert.Equal("/dir", fs.CopyDestination);
    }
}