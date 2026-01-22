namespace lab21v3;

public class NightShippingStrategy : IShippingStrategy
{
    public decimal CalculateCost(decimal distance, decimal weight)
    {
        decimal standardCost = distance * 1.5m + weight * 0.5m;
        return standardCost + 30m;
    }
}
