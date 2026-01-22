using System;
using System.Collections.Generic;
using System.Linq;

public delegate double AccountOperation(double a, double b);

class Program
{
    static void Main(string[] args)
    {
        List<BankAccount> accounts = new()
        {
            new BankAccount("ACC-1001", 2500),
            new BankAccount("ACC-1002", 1500.50),
            new BankAccount("ACC-1003", 990),
            new BankAccount("ACC-1004", 7200),
            new BankAccount("ACC-1005", 410)
        };

        AccountOperation add = (x, y) => x + y;
        Console.WriteLine($"Add: {add(2500, 1500)}\n");

        AccountOperation subtract = delegate (double x, double y)
        {
            return x - y;
        };
        Console.WriteLine($"Subtract: {subtract(2500, 1500)}\n");

        Func<List<BankAccount>, double> avgBalance =
            list => list.Average(a => a.Balance);

        Console.WriteLine($"Average balance: {avgBalance(accounts):F2}\n");

        var minAcc = accounts.MinBy(a => a.Balance);
        Console.WriteLine($"Min balance: {minAcc.Number} : {minAcc.Balance}\n");

        Action<BankAccount> print =
            acc => Console.WriteLine($"{acc.Number} : {acc.Balance}");

        Console.WriteLine("All accounts:");
        accounts.ForEach(print);
        Console.WriteLine();

        Console.WriteLine("Sorted by balance:");
        foreach (var a in accounts.OrderBy(a => a.Balance))
            print(a);
        Console.WriteLine();

        double total = accounts.Aggregate(0.0, (sum, a) => sum + a.Balance);
        Console.WriteLine($"Total balance = {total:F2}");
    }
}
