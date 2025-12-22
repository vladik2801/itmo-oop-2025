using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Results;
using Itmo.ObjectOrientedProgramming.Lab5.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;
using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Abstractions.Persistence.Queries;
using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Mapping;

namespace Lab5.Application.Services;

public class AccountService : Contracts.Accounts.IAccountService
{
    private readonly IPersistenceContext _persistenceContext;

    public AccountService(IPersistenceContext persistenceContext)
    {
        _persistenceContext = persistenceContext;
    }

    public AccountBalanceModel GetBalance(Guid sessionId)
    {
        UserSession? session = _persistenceContext.UserSessions
            .Query(new UserSessionQuery(new[] { new SessionId(sessionId) }))
            .FirstOrDefault();

        if (session is null)
            return new AccountBalanceModel(0);

        Account? account = _persistenceContext.Accounts
            .Query(new AccountQuery(new[] { session.AccountId }))
            .FirstOrDefault();

        if (account is null)
            return new AccountBalanceModel(0);

        return new AccountBalanceModel(account.Balance.Value);
    }

    public OperationHistoryModel GetHistory(Guid sessionId)
    {
        UserSession? session = _persistenceContext.UserSessions
            .Query(new UserSessionQuery(new[] { new SessionId(sessionId) }))
            .FirstOrDefault();

        if (session is null)
            return new OperationHistoryModel(Array.Empty<AccountOperationModel>());

        IEnumerable<AccountTransaction> transactions = _persistenceContext.OperationHistory
            .Query(new OperationHistoryQuery(new[] { session.AccountId }));

        return transactions.MapToModel();
    }

    public DepositOperation.Response Deposit(DepositOperation.Request request)
    {
        UserSession? session = _persistenceContext.UserSessions
            .Query(new UserSessionQuery(new[] { new SessionId(request.SessionId) }))
            .FirstOrDefault();

        if (session is null)
            return new DepositOperation.Response.Failure("User session not found");

        Account? account = _persistenceContext.Accounts
            .Query(new AccountQuery(new[] { session.AccountId }))
            .FirstOrDefault();

        if (account is null)
            return new DepositOperation.Response.Failure("Account not found");

        var amount = new Money(request.Amount);

        DepositResult result = account.Deposit(amount);

        if (result is DepositResult.Failure f)
            return new DepositOperation.Response.Failure(f.Message);

        var success = (DepositResult.Success)result;

        _persistenceContext.Accounts.Update(account);
        _persistenceContext.OperationHistory.Add(new AccountTransaction(
            TransactionType.Deposit,
            amount,
            session.AccountId));

        return new DepositOperation.Response.Success(
            new AccountBalanceModel(success.NewBalance.Value));
    }

    public WithdrawOperation.Response Withdraw(WithdrawOperation.Request request)
    {
        UserSession? session = _persistenceContext.UserSessions
            .Query(new UserSessionQuery(new[] { new SessionId(request.SessionId) }))
            .FirstOrDefault();

        if (session is null)
            return new WithdrawOperation.Response.Failure("User session not found");

        Account? account = _persistenceContext.Accounts
            .Query(new AccountQuery(new[] { session.AccountId }))
            .FirstOrDefault();

        if (account is null)
            return new WithdrawOperation.Response.Failure("Account not found");

        var amount = new Money(request.Amount);

        WithdrawResult result = account.Withdraw(amount);

        if (result is WithdrawResult.Failure f)
            return new WithdrawOperation.Response.Failure(f.Message);

        var success = (WithdrawResult.Success)result;

        _persistenceContext.Accounts.Update(account);
        _persistenceContext.OperationHistory.Add(new AccountTransaction(
            TransactionType.Withdraw,
            amount,
            session.AccountId));

        return new WithdrawOperation.Response.Success(
            new AccountBalanceModel(success.NewBalance.Value));
    }

    public CreateAccountOperation.Response CreateAccount(CreateAccountOperation.Request request)
    {
        AdminSession? admin = _persistenceContext.AdminSessions
            .Query(new AdminSessionQuery(new[] { new SessionId(request.AdminSessionId) }))
            .FirstOrDefault();

        if (admin is null)
            return new CreateAccountOperation.Response.Failure("Unauthorized");

        var accountId = new AccountId(request.AccountId);

        Account? existing = _persistenceContext.Accounts
            .Query(new AccountQuery(new[] { accountId }))
            .FirstOrDefault();

        if (existing is not null)
            return new CreateAccountOperation.Response.Failure("Account already exists");

        _persistenceContext.Accounts.Add(new Account(accountId, new PinCode(request.PinCode)));

        return new CreateAccountOperation.Response.Success();
    }
}