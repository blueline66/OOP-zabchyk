using System;

namespace IndependentWork16
{
    public class OrderRepository : IOrderRepository
    {
        public void Save(int orderId)
        {
            Console.WriteLine($"Збереження замовлення {orderId} у базу даних...");
        }
    }
}
