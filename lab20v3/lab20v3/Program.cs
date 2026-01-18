using System;

namespace Lab20
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new OrderValidator();
            var repository = new InMemoryOrderRepository();
            var emailService = new ConsoleEmailService();

            var orderService = new OrderService(validator, repository, emailService);

            Console.WriteLine("=== Valid Order ===");
            var validOrder = new Order(1, "Darina", 1500);
            orderService.ProcessOrder(validOrder);

            Console.WriteLine("\n=== Invalid Order ===");
            var invalidOrder = new Order(2, "Anna", -10);
            orderService.ProcessOrder(invalidOrder);
        }
    }
}
