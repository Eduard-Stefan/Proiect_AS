using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class PcCaseShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShippingCost(ProductDto product)
        {
            return 10.00m;
        }
    }
}
