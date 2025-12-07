using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class FileEntity : IFileSystemEntity
{
    public FileEntity(string path, string content)
    {
        Path = path;
        Content = content;
    }

    public string Path { get; set; }

    public string Content { get; set; }

    public void Accept(IFileSystemEntityVisitor visitor)
    {
        visitor.Visit(this);
    }
}