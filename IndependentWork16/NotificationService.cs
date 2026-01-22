using System;

namespace IndependentWork16
{
    public class NotificationService : INotificationService
    {
        public void Notify(int orderId)
        {
            Console.WriteLine($"Відправка сповіщення по замовленню {orderId}...");
        }
    }
}
