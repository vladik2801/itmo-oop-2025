using Lab5.Application.Contracts.Accounts.Models;

namespace Lab5.Application.Contracts.Accounts.Operations;

public static class WithdrawOperation
{
    public readonly record struct Request(Guid SessionId, decimal Amount);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(AccountBalanceModel Balance) : Response;

        public sealed record Failure(string Message) : Response;
    }
}