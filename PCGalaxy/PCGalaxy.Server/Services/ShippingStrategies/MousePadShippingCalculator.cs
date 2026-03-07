using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class MousePadShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShippingCost(ProductDto product)
        {
            return 8.00m;
        }
    }
}
