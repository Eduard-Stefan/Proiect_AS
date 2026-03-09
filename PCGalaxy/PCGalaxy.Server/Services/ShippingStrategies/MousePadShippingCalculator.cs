using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class MousePadShippingCalculator : IShippingCalculator
    {
        // Charges full price for the first unit but applies an extremely low marginal cost for every additional unit.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            return 12.00m + ((quantity - 1) * 1.00m);
        }
    }
}
