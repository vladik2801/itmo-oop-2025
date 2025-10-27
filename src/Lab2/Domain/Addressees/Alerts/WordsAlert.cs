using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;

public class WordsAlert : IAlertDecision
{
    private readonly string[] _alertedWords;

    public WordsAlert(IEnumerable<string> triggerWords)
    {
        _alertedWords = triggerWords.ToArray();
    }

    public string? GetReason(Message message)
    {
        string text = (message.Title + " " + message.Body).ToLowerInvariant();
        foreach (string alertedWord in _alertedWords)
        {
            if (!string.IsNullOrEmpty(alertedWord))
            {
                return $"Trigered word : {alertedWord}";
            }
        }

        return null;
    }
}