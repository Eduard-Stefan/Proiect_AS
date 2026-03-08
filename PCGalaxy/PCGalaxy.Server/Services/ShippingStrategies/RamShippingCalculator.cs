using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class RamShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            return 12.00m;
        }
    }
}
