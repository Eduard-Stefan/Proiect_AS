using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class MotherboardShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            return 7.00m;
        }
    }
}
