
using System;

public class PayPalService : IPayPalPayment
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата через PayPal: {amount} грн");
    }
}
