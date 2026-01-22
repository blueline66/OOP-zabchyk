using System;

namespace IndependentWork16
{
    public class OrderValidator : IOrderValidator
    {
        public bool Validate(int orderId)
        {
            Console.WriteLine($"Перевірка замовлення {orderId}...");
            return true;
        }
    }
}
