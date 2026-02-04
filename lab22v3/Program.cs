using System;
using System.Text;
using Bad = lab22.Violation;
using Good = lab22.Fixed;

namespace lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Лабораторна 22: Аналіз LSP";

            RunViolationScenario();
            Console.WriteLine(new string('-', 30));
            RunFixedScenario();

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }

        static void RunViolationScenario()
        {
            Console.WriteLine("=== СЦЕНАРІЙ 1: ПОРУШЕННЯ LSP ===");
            
            Bad.Account regular = new Bad.Account(2000);
            Bad.Account savings = new Bad.SavingsAccount(2000);

            TestWithdrawalBad(regular, 1500);
            TestWithdrawalBad(savings, 1500);
        }

        static void TestWithdrawalBad(Bad.Account account, decimal amount)
        {
            Console.WriteLine($"\nСпроба зняття {amount} з рахунку {account.GetType().Name}...");
            try
            {
                account.Withdraw(amount);
                Console.WriteLine($"Успішно! Залишок: {account.Balance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ПОМИЛКА (Неочікувано для базового контракту): {ex.Message}");
            }
        }

        static void RunFixedScenario()
        {
            Console.WriteLine("\n=== СЦЕНАРІЙ 2: ВИПРАВЛЕННЯ (LSP) ===");

            Good.BankAccount checking = new Good.CheckingAccount(2000);
            Good.BankAccount savings = new Good.SavingsAccount(2000);

            TestWithdrawalGood(checking, 1500);
            TestWithdrawalGood(savings, 1500);
        }

        static void TestWithdrawalGood(Good.BankAccount account, decimal amount)
        {
            Console.WriteLine($"\nЗапит на зняття {amount} з рахунку {account.GetType().Name}...");
            try
            {
                account.Withdraw(amount);
                Console.WriteLine($"Підтверджено. Залишок: {account.Balance}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Відмовлено (Очікувана логіка): {ex.Message}");
            }
        }
    }
}