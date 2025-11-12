using System;
using System.Collections.Generic;
using System.Linq;
using Lab5v3.Utils;
using Lab5v3.Exceptions;

namespace Lab5v3.Models
{
    public class Account
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Owner { get; }
        private readonly List<Transaction> _transactions = new();

        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

        public Account(string owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public Result<Transaction> AddTransaction(Transaction tx)
        {
            if (tx == null)
                return Result<Transaction>.Fail("Транзакція дорівнює null.");

            if (tx.Type == TransactionType.Withdrawal && tx.Amount > Balance())
                throw new InsufficientFundsException("Недостатньо коштів для зняття.");

            _transactions.Add(tx);
            return Result<Transaction>.Ok(tx);
        }

        public decimal Balance() => _transactions.Sum(t => t.SignedAmount());

        public override string ToString() =>
            $"Account {Id} | Owner: {Owner} | Balance: {Balance():C}";
    }
}
