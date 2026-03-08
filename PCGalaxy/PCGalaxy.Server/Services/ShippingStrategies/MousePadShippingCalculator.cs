using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class MousePadShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            return 8.00m;
        }
    }
}
