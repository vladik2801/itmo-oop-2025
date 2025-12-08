namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class FileSystemContext
{
    public FileSystemContext(UnixPathService pathService)
    {
        PathService = pathService;
        CurrentPath = "/";
    }

    public IFileSystem? FileSystem { get; set; }

    public string? CurrentPath { get; set; }

    public UnixPathService PathService { get; }
}