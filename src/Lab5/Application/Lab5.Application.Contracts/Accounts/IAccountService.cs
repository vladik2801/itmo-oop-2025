using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Accounts.Operations;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    AccountBalanceModel GetBalance(Guid sessionId);

    OperationHistoryModel GetHistory(Guid sessionId);

    DepositOperation.Response Deposit(DepositOperation.Request request);

    WithdrawOperation.Response Withdraw(WithdrawOperation.Request request);

    CreateAccountOperation.Response CreateAccount(CreateAccountOperation.Request request);
}