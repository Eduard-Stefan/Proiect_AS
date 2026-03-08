using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class CpuShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            return 1.00m;
        }
    }
}
