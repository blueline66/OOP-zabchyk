using System;

namespace lab22.Fixed
{
    public abstract class BankAccount
    {
        public decimal Balance { get; protected set; }

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public abstract void Withdraw(decimal amount);
    }

    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(decimal initialBalance) : base(initialBalance) { }

        public override void Withdraw(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Сума не може бути від'ємною");

            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Недостатньо коштів");
            }
        }
    }

    public class SavingsAccount : BankAccount
    {
        private decimal _minBalance = 1000m;

        public SavingsAccount(decimal initialBalance) : base(initialBalance) { }

        public override void Withdraw(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Сума не може бути від'ємною");

            if (Balance - amount < _minBalance)
            {
                throw new InvalidOperationException($"Відхилено. Баланс повинен залишатися вище {_minBalance}");
            }

            Balance -= amount;
        }
    }
}