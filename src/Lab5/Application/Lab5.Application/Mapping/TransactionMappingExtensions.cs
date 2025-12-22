using Itmo.ObjectOrientedProgramming.Lab5.Accounts;
using Lab5.Application.Contracts.Accounts.Models;

namespace Lab5.Application.Mapping;

public static class TransactionMappingExtensions
{
    public static AccountOperationModel MapToModel(this AccountTransaction transaction)
        => new AccountOperationModel(transaction.TransactionType.ToString(), transaction.Amount.Value);

    public static OperationHistoryModel MapToModel(this IEnumerable<AccountTransaction> transactions)
        => new OperationHistoryModel(transactions.Select(t => t.MapToModel()).ToList());
}