using System;
using Lab5v3.Exceptions;

namespace Lab5v3.Models
{
    public class Transaction
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime Date { get; }
        public decimal Amount { get; }
        public TransactionType Type { get; }
        public string Description { get; }

        public Transaction(DateTime date, decimal amount, TransactionType type, string description = "")
        {
            if (amount <= 0)
                throw new InvalidTransactionException("Сума транзакції має бути додатньою.");
            Date = date;
            Amount = amount;
            Type = type;
            Description = description;
        }

        public decimal SignedAmount() =>
            Type == TransactionType.Withdrawal ? -Amount : Amount;

        public override string ToString() =>
            $"{Date:yyyy-MM-dd} | {Type} | {Amount:C} | {Description}";
    }
}
