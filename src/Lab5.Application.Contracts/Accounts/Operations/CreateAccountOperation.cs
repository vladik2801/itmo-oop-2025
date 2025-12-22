namespace Lab5.Application.Contracts.Accounts.Operations;

public static class CreateAccountOperation
{
    public readonly record struct Request(Guid AdminSessionId, long AccountId, int PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success : Response;

        public sealed record Failure(string Message) : Response;
    }
}