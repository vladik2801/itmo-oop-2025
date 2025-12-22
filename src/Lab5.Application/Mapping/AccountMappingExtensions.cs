using Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;
using Lab5.Application.Contracts.Accounts.Models;

namespace Lab5.Application.Mapping;

public static class AccountMappingExtensions
{
    public static AccountBalanceModel MapToModel(this Money money)
        => new AccountBalanceModel(money.Value);
}