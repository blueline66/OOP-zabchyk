using System;

namespace lab22.Violation
{
    public class Account
    {
        public decimal Balance { get; protected set; }

        public Account(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Сума не може бути від'ємною");

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

    public class SavingsAccount : Account
    {
        private decimal _minBalance = 1000m;

        public SavingsAccount(decimal initialBalance) : base(initialBalance) { }

        public override void Withdraw(decimal amount)
        {
            if (Balance - amount < _minBalance)
            {
                throw new InvalidOperationException($"Неможливо зняти кошти. Баланс не може бути меншим за {_minBalance}");
            }

            base.Withdraw(amount);
        }
    }
}