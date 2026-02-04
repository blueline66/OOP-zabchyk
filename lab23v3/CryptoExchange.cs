
using System;

public class CryptoExchange : ICryptoPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата криптовалютою: {amount}");
    }
}
