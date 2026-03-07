using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class MonitorShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShippingCost(ProductDto product)
        {
            return 6.00m;
        }
    }
}
