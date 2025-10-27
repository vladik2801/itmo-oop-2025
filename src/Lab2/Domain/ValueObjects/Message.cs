using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

public sealed record class Message(NonEmptyText Title, NonEmptyText Body, Priority Priority)
{
    public static Result<Message> Create(string? title, string? body, Priority priority)
    {
        Result<NonEmptyText> t = NonEmptyText.TryCreate(title);
        if (!t.IsSuccess) return Result<Message>.Fail(t.Code, t.Message);

        Result<NonEmptyText> b = NonEmptyText.TryCreate(body);
        if (!b.IsSuccess) return Result<Message>.Fail(b.Code, b.Message);

        return Result<Message>.Ok(new(t.Value, b.Value, priority));
    }
}