using System;

namespace IndependentWork16
{
    
    public class OrderProcessor
    {
        public void ProcessOrder(int orderId)
        {
            if (!ValidateOrder(orderId))
            {
                Console.WriteLine("Замовлення некоректне.");
                return;
            }

            SaveOrderToDatabase(orderId);
            SendNotification(orderId);

            Console.WriteLine("Замовлення успішно оброблено.");
        }

        private bool ValidateOrder(int orderId)
        {
            Console.WriteLine($"Перевірка замовлення {orderId}...");
            return true;
        }

        private void SaveOrderToDatabase(int orderId)
        {
            Console.WriteLine($"Збереження замовлення {orderId} у базу даних...");
        }

        private void SendNotification(int orderId)
        {
            Console.WriteLine($"Відправка сповіщення по замовленню {orderId}...");
        }
    }
}
