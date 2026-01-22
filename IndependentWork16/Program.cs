using System;

namespace IndependentWork16
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IOrderValidator validator = new OrderValidator();
            IOrderRepository repository = new OrderRepository();
            INotificationService notifier = new NotificationService();

            
            OrderService orderService = new OrderService(validator, repository, notifier);

            
            orderService.ProcessOrder(101);

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}

