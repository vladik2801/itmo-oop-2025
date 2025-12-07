namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

public interface IFileOutputMode
{
    string Mode { get; }

    void Show(string filePath, string context);
}