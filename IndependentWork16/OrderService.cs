using System;

namespace IndependentWork16
{
    public class OrderService
    {
        private readonly IOrderValidator _validator;
        private readonly IOrderRepository _repository;
        private readonly INotificationService _notifier;

        public OrderService(IOrderValidator validator, IOrderRepository repository, INotificationService notifier)
        {
            _validator = validator;
            _repository = repository;
            _notifier = notifier;
        }

        public void ProcessOrder(int orderId)
        {
            if (!_validator.Validate(orderId))
            {
                Console.WriteLine("Замовлення некоректне.");
                return;
            }

            _repository.Save(orderId);
            _notifier.Notify(orderId);

            Console.WriteLine("Замовлення успішно оброблено.");
        }
    }
}
