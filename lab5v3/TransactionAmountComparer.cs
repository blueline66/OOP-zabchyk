using System.Collections.Generic;
using Lab5v3.Models;

namespace Lab5v3.Utils
{
    public class TransactionAmountComparer : IComparer<Transaction>
    {
        public int Compare(Transaction x, Transaction y) =>
            x.Amount.CompareTo(y.Amount);
    }
}
