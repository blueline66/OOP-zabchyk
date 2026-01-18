using System;

namespace Lab20
{
    public class ConsoleEmailService : IEmailService
    {
        public void SendOrderConfirmation(Order order)
        {
            Console.WriteLine($"📧 Email sent to {order.CustomerName}");
        }
    }
}
