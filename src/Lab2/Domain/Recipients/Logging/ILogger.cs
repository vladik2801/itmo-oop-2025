namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Logging;

public interface ILogger
{
    void Info(string text);

    void Warn(string text);

    void ErrorL(string text, Exception? ex = null);
}