using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class DefaultShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            return 0.00m;
        }
    }
}
