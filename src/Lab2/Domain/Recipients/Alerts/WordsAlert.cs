using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Alerts;

public class WordsAlert : IAlertDecision
{
    private readonly HashSet<string> _alertedWords = new();

    public WordsAlert(IEnumerable<string> triggerWords)
    {
        ArgumentNullException.ThrowIfNull(triggerWords);
        _alertedWords = new HashSet<string>(triggerWords.Where(w => !string.IsNullOrWhiteSpace(w))
            .Select(w => w.ToLowerInvariant()));
    }

    public bool TryGetAlertReason(Message message, out string reason)
    {
        string suspectText = $"{message.Title}\n{message.Body}".ToLowerInvariant();
        foreach (string alertedWord in _alertedWords)
        {
            if (suspectText.Contains(alertedWord, StringComparison.OrdinalIgnoreCase))
            {
                reason = $"Suspicious word detected: '{alertedWord}'";
                return true;
            }
        }

        reason = string.Empty;
        return false;
    }
}