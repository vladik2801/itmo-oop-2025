namespace Lab5.Application.Contracts.Sessions.Operations;

public static class CreateAdminSessionOperation
{
    public readonly record struct Request(string SystemPassword);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(Guid SessionId) : Response;

        public sealed record Failure(string Message) : Response;
    }
}