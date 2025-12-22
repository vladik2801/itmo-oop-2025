namespace Lab5.Application.Contracts.Accounts.Operations;

public static class CreateUserSessionOperation
{
    public readonly record struct Request(long AccountId, string PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(Guid SessionId) : Response;

        public sealed record Failure(string Message) : Response;
    }
}