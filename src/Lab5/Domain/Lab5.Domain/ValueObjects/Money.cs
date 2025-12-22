namespace Itmo.ObjectOrientedProgramming.Lab5.ValueObjects;

public readonly record struct Money
{
    public Money(decimal amount)
    {
        if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be better than 0");
        Value = amount;
    }

    public decimal Value { get; }

    public Money Add(Money money) => new(Value + money.Value);

    public Money Subtract(Money money)
    {
        if (Value < money.Value) throw new InvalidOperationException("Insufficient funds");
        return new Money(Value - money.Value);
    }
}