using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

public sealed class Message
{
    public Message(NonEmptyText title, NonEmptyText body, Priority priority)
    {
        Title = title.Value;
        Body = body.Value;
        Priority = priority;
    }

    public string Title { get; }

    public string Body { get; }

    public Priority Priority { get; }
}