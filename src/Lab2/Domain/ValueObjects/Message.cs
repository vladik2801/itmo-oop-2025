using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

public sealed record Message
{
    public Message(string title, string body, Priority priority)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be null or whitespace.", nameof(title));

        if (string.IsNullOrWhiteSpace(body))
            throw new ArgumentException("Body cannot be null or whitespace.", nameof(body));
        Title = title;
        Body = body;
        Priority = priority;
    }

    public string Title { get; }

    public string Body { get; }

    public Priority Priority { get; }
}