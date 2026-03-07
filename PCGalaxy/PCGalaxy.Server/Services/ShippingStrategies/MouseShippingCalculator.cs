using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class MouseShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShippingCost(ProductDto product)
        {
            return 9.00m;
        }
    }
}
