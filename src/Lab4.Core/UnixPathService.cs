namespace Itmo.ObjectOrientedProgramming.Lab4.Core;

public class UnixPathService
{
    public static string[] SplitPath(string path)
    {
        return path.Split('/', StringSplitOptions.RemoveEmptyEntries);
    }

    public bool IsAbsolutePath(string path)
    {
        return path.StartsWith('/');
    }

    public string Convert(string currentLocalPath, string path)
    {
        var segments = new List<string>();
        if (!IsAbsolutePath(currentLocalPath))
        {
            foreach (string segment in SplitPath(currentLocalPath))
            {
                segments.Add(segment);
            }
        }

        string workingPath = path;
        if (IsAbsolutePath(path))
        {
            segments.Clear();
        }

        foreach (string segment in SplitPath(workingPath))
        {
            if (segment is "" or ".") continue;
            if (segment is "..")
            {
                if (segments.Count > 0) segments.RemoveAt(segments.Count - 1);
                continue;
            }

            segments.Add(segment);
        }

        return "/" + string.Join("/", segments);
    }
}