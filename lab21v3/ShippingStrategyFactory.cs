namespace lab21v3;

using System;

public static class ShippingStrategyFactory
{
    public static IShippingStrategy CreateStrategy(string deliveryType)
    {
        return deliveryType switch
        {
            "standard" => new StandardShippingStrategy(),
            "express" => new ExpressShippingStrategy(),
            "international" => new InternationalShippingStrategy(),
            "night" => new NightShippingStrategy(),
            _ => throw new ArgumentException("Невідомий тип доставки")
        };
    }
}
