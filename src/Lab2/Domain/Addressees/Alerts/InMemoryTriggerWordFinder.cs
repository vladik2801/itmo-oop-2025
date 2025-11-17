using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;

public class InMemoryTriggerWordFinder : ITriggerWordFinder
{
    private readonly string[] _alertedWords;

    public InMemoryTriggerWordFinder(IEnumerable<string> triggerWords)
    {
        _alertedWords = triggerWords.ToArray();
    }

    public bool IsTriggerWord(Message message)
    {
        foreach (string triggerWord in _alertedWords)
        {
            if (triggerWord.Contains(message.Title, StringComparison.InvariantCultureIgnoreCase)
                || triggerWord.Contains(message.Body, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
}