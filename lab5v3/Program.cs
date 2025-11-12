using System;
using System.Linq;
using Lab5v3.Models;
using Lab5v3.Repositories;
using Lab5v3.Utils;
using Lab5v3.Exceptions;

namespace Lab5v3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Lab5v3 — Generics, Collections, LINQ, Exceptions ===\n");

            var accountsRepo = new Repository<Account>();
            var acc = new Account("Darina Zhabych");
            accountsRepo.Add(acc);

            var txs = new[]
            {
                new Transaction(new DateTime(2025, 10, 01), 1000m, TransactionType.Deposit, "Зарплата"),
                new Transaction(new DateTime(2025, 10, 05), 200m, TransactionType.Withdrawal, "Продукти"),
                new Transaction(new DateTime(2025, 10, 10), 150m, TransactionType.Withdrawal, "Кафе"),
                new Transaction(new DateTime(2025, 09, 20), 500m, TransactionType.Deposit, "Повернення"),
                new Transaction(new DateTime(2025, 10, 15), 1200m, TransactionType.Deposit, "Фріланс"),
                new Transaction(new DateTime(2025, 10, 20), 300m, TransactionType.Withdrawal, "Одяг")
            };

            foreach (var tx in txs)
            {
                var r = acc.AddTransaction(tx);
                if (!r.Success)
                    Console.WriteLine($"Помилка при додаванні транзакції: {r.Error}");
            }

            try
            {
                Console.WriteLine("\nСпроба зняти надто велику суму...");
                var bigWithdrawal = new Transaction(DateTime.Now, 10000m, TransactionType.Withdrawal, "Велике зняття");
                acc.AddTransaction(bigWithdrawal);
            }
            catch (InsufficientFundsException ife)
            {
                Console.WriteLine($"Caught InsufficientFundsException: {ife.Message}");
            }

            Console.WriteLine($"\n{acc}\n");
            Console.WriteLine("Всі транзакції:");
            foreach (var t in acc.Transactions.OrderBy(t => t.Date))
                Console.WriteLine(t);

            var balance = acc.Balance();
            Console.WriteLine($"\nПоточний баланс: {balance:C}");

            var totalDeposits = acc.Transactions.Where(t => t.Type == TransactionType.Deposit).Sum(t => t.Amount);
            var totalWithdrawals = acc.Transactions.Where(t => t.Type == TransactionType.Withdrawal).Sum(t => t.Amount);
            Console.WriteLine($"Сума депозитів: {totalDeposits:C}");
            Console.WriteLine($"Сума зняттів: {totalWithdrawals:C}");

            var avgTx = acc.Transactions.Average(t => t.Amount);
            Console.WriteLine($"Середня сума транзакції: {avgTx:C}");

            var monthly = acc.Transactions
                .GroupBy(t => new { t.Date.Year, t.Date.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Deposits = g.Where(t => t.Type == TransactionType.Deposit).Sum(t => t.Amount),
                    Withdrawals = g.Where(t => t.Type == TransactionType.Withdrawal).Sum(t => t.Amount),
                    Net = g.Sum(t => t.SignedAmount())
                });

            Console.WriteLine("\nЩомісячні підсумки:");
            foreach (var m in monthly)
                Console.WriteLine($"{m.Year}-{m.Month:00} | +{m.Deposits:C} / -{m.Withdrawals:C} / Δ {m.Net:C}");

            var comparer = new TransactionAmountComparer();
            var txMax = GenericUtils.Max(acc.Transactions, comparer);
            Console.WriteLine($"\nНайбільша транзакція: {txMax.Amount:C} ({txMax.Type})");

            Console.WriteLine("\n=== Кінець демонстрації ===");
        }
    }
}
