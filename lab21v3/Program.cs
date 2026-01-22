using System;
using lab21v3;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Розрахунок вартості доставки ===");

        Console.Write("Тип доставки (standard / express / international / night): ");
        string type = Console.ReadLine()?.ToLower();

        if (string.IsNullOrWhiteSpace(type))
        {
            Console.WriteLine("Тип доставки не може бути порожнім.");
            return;
        }

        Console.Write("Відстань (км): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal distance))
        {
            Console.WriteLine("Некоректна відстань.");
            return;
        }

        Console.Write("Вага (кг): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal weight))
        {
            Console.WriteLine("Некоректна вага.");
            return;
        }

        try
        {
            IShippingStrategy strategy =
                ShippingStrategyFactory.CreateStrategy(type);

            DeliveryService service = new DeliveryService();
            decimal cost = service.CalculateDeliveryCost(distance, weight, strategy);

            Console.WriteLine($"Вартість доставки: {cost} грн");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}

