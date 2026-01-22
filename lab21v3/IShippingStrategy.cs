namespace lab21v3;

public interface IShippingStrategy
{
    decimal CalculateCost(decimal distance, decimal weight);
}
