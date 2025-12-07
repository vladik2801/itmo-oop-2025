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
        Session session = new();
        FileSystemMock fs = new();
        ConnectCommand command = new(session, fs, "/");

        // Act
        OperationResult result = command.Execute();

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.NotNull(session.FileSystem);
        Assert.Equal("/", session.LocalPath);
    }

    [Fact]
    public void DisconnectCommand_WhenNotConnected_ReturnsFailure()
    {
        // Arrange
        Session session = new();
        DisconnectCommand command = new(session);

        // Act
        OperationResult result = command.Execute();

        // Assert
        OperationResult.Failure failure = Assert.IsType<OperationResult.Failure>(result);
        Assert.False(string.IsNullOrWhiteSpace(failure.Message));
        Assert.Null(session.FileSystem);
    }

    [Fact]
    public void DisconnectCommand_WhenConnected_ClearsFileSystem()
    {
        // Arrange
        Session session = new();
        FileSystemMock fs = new();
        session.Connect(fs);
        DisconnectCommand command = new(session);

        // Act
        OperationResult result = command.Execute();

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.Null(session.FileSystem);
        Assert.Equal("/", session.LocalPath);
    }

    [Fact]
    public void TreeListCommand_WhenNotConnected_ReturnsNotConnected()
    {
        // Arrange
        Session session = new();
        OutputWriterMock writer = new();
        TreeListCommand command = new(session, 2, writer);

        // Act
        OperationResult result = command.Execute();

        // Assert
        OperationResult.Failure failure = Assert.IsType<OperationResult.Failure>(result);
        Assert.Equal("Not connected", failure.Message);
        Assert.Equal(string.Empty, writer.WrittenText);
    }

    [Fact]
    public void TreeListCommand_WithValidRootDirectory_WritesTree()
    {
        // Arrange
        Session session = new();
        FileSystemMock fs = new();
        DirectoryEntity root = new("/");
        fs.Directory = root;
        session.Connect(fs);
        session.LocalPath = "/";
        OutputWriterMock writer = new();
        TreeListCommand command = new(session, 1, writer);

        // Act
        OperationResult result = command.Execute();

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.Contains('/', writer.WrittenText);
    }

    [Fact]
    public void TreeListCommand_WhenDirectoryNotFound_ReturnsFailure()
    {
        // Arrange
        Session session = new();
        FileSystemMock fs = new();
        fs.Directory = null;
        session.Connect(fs);
        session.LocalPath = "/unknown";
        OutputWriterMock writer = new();
        TreeListCommand command = new(session, 1, writer);

        // Act
        OperationResult result = command.Execute();

        // Assert
        OperationResult.Failure failure = Assert.IsType<OperationResult.Failure>(result);
        Assert.Equal("Directory not found", failure.Message);
    }

    [Fact]
    public void FileMoveCommand_WhenConnected_CallsFileSystemMoveFile()
    {
        // Arrange
        Session session = new();
        FileSystemMock fs = new();
        session.Connect(fs);
        FileMoveCommand command = new(session, "/src.txt", "/destDir");

        // Act
        OperationResult result = command.Execute();

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
        Session session = new();
        FileSystemMock fs = new();
        session.Connect(fs);
        FileDeleteCommand command = new(session, "/toDelete.txt");

        // Act
        OperationResult result = command.Execute();

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.True(fs.DeleteCalled);
        Assert.Equal("/toDelete.txt", fs.DeletePath);
    }

    [Fact]
    public void FileRenameCommand_WhenConnected_CallsFileSystemRenameFile()
    {
        // Arrange
        Session session = new();
        FileSystemMock fs = new();
        session.Connect(fs);
        FileRenameCommand command = new(session, "/old.txt", "new.txt");

        // Act
        OperationResult result = command.Execute();

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
        Session session = new();
        FileSystemMock fs = new();
        session.Connect(fs);
        FileCopyCommand command = new(session, "/a.txt", "/dir");

        // Act
        OperationResult result = command.Execute();

        // Assert
        Assert.IsType<OperationResult.Succes>(result);
        Assert.True(fs.CopyCalled);
        Assert.Equal("/a.txt", fs.CopySource);
        Assert.Equal("/dir", fs.CopyDestination);
    }
}