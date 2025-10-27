namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Logging;

public interface ILogger
{
    void Info(string text);

    void Warn(string text);

    void LogError(string text, Exception? ex = null);
}