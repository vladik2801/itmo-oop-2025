using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Services;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string rootPath)
    {
        Root = new DirectoryEntity(rootPath);
    }

    public DirectoryEntity Root { get; }

    public IEnumerable<IFileSystemEntity> EnumerateChildren(DirectoryEntity directory)
    {
        return directory.Children;
    }

    public DirectoryEntity? GetDirectoryByPath(string path)
    {
        if (path == "/" || path == Root.Path) return Root;
        string[] segments = UnixPathService.SplitPath(path);
        if (segments.Length == 0) return Root;

        DirectoryEntity current = Root;

        for (int i = 0; i < segments.Length; i++)
        {
            string segment = segments[i];
            DirectoryEntity? nextDirectory = FindChildDirectory(current, segment);
            if (nextDirectory == null) return null;
            current = nextDirectory;
        }

        return current;
    }

    public string ReadFile(string path)
    {
        FileEntity? fileEntity = GetFile(path);
        if (fileEntity == null) throw new InvalidOperationException("not found file");
        return fileEntity.Content;
    }

    public FileEntity? GetFile(string path)
    {
        string? parentPath = GetParentPath(path);
        if (parentPath == null) return null;

        DirectoryEntity? parent = GetDirectoryByPath(parentPath);
        if (parent == null) return null;
        string filename = GetLastSegment(path);
        return FindChildFile(parent, filename);
    }

    public OperationResult MoveFile(string sourcePath, string destDirectoryPath)
    {
        FileEntity? file = GetFile(sourcePath);
        if (file == null) return new OperationResult.Failure("not found file");

        DirectoryEntity? sourceParent = GetDirectoryByPath(GetParentPath(sourcePath));
        if (sourceParent == null) return new OperationResult.Failure("not found directory");

        DirectoryEntity? destParent = GetDirectoryByPath(destDirectoryPath);
        if (destParent == null) return new OperationResult.Failure("not found directory");

        RemoveChild(sourceParent, file);
        string newFileAbsolutePath = Combine(destDirectoryPath, GetLastSegment(sourcePath));
        UpdateEntityPath(file, newFileAbsolutePath);
        destParent.AddChild(file);
        return new OperationResult.Succes();
    }

    public OperationResult CopyFile(string sourcePath, string destDirectoryPath)
    {
        FileEntity? file = GetFile(sourcePath);
        if (file == null) return new OperationResult.Failure("not found file");

        DirectoryEntity? destDir = GetDirectoryByPath(destDirectoryPath);
        if (destDir == null) return new OperationResult.Failure("not found directory");

        string filename = GetLastSegment(sourcePath);
        string newPath = Combine(destDirectoryPath, filename);
        var copy = new FileEntity(newPath, file.Content);

        destDir.AddChild(copy);
        return new OperationResult.Succes();
    }

    public OperationResult DeleteFile(string path)
    {
        DirectoryEntity? parent = GetDirectoryByPath(GetParentPath(path));
        if (parent == null) return new OperationResult.Failure("not found parent");

        FileEntity? file = GetFile(path);
        if (file == null) return new OperationResult.Failure("not found file");

        RemoveChild(parent, file);
        return new OperationResult.Succes();
    }

    public OperationResult RenameFile(string sourcePath, string newName)
    {
        FileEntity? file = GetFile(sourcePath);
        if (file == null) return new OperationResult.Failure("not found file");
        string parent = GetParentPath(sourcePath);
        string newPath = Combine(parent, newName);
        UpdateEntityPath(file, newPath);
        return new OperationResult.Succes();
    }

    private static FileEntity? FindChildFile(DirectoryEntity parent, string path)
    {
        foreach (IFileSystemEntity child in parent.Children)
        {
            if (child is FileEntity fileEntity)
            {
                string fileName = GetLastSegment(fileEntity.Path);
                if (fileName == path) return fileEntity;
            }
        }

        return null;
    }

    private static DirectoryEntity? FindChildDirectory(DirectoryEntity parent, string name)
    {
        foreach (IFileSystemEntity child in parent.Children)
        {
            if (child is DirectoryEntity dir)
            {
                string dirName = GetLastSegment(dir.Path);
                if (dirName == name)
                    return dir;
            }
        }

        return null;
    }

    private static string GetParentPath(string absolutePath)
    {
        string[] segments = UnixPathService.SplitPath(absolutePath);
        if (segments.Length == 0) throw new ArgumentException("Path is empty");
        if (segments.Length == 1) return "/";

        return "/" + string.Join("/", segments, 0, segments.Length - 1);
    }

    private static string GetLastSegment(string path)
    {
        string[] segments = UnixPathService.SplitPath(path);
        return segments.Length == 0 ? string.Empty : segments[segments.Length - 1];
    }

    private static string Combine(string dir, string name)
    {
        if (dir == "/") return "/" + name;
        return dir + "/" + name;
    }

    private static void RemoveChild(DirectoryEntity parent, IFileSystemEntity child)
    {
        var list = (List<IFileSystemEntity>)parent.Children;
        list.Remove(child);
    }

    private static void UpdateEntityPath(IFileSystemEntity entity, string newPath)
    {
        if (entity is FileEntity fileEntity) fileEntity.Path = newPath;
        else if (entity is DirectoryEntity directoryEntity) directoryEntity.Path = newPath;
    }
}