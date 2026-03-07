using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class CoolerShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShippingCost(ProductDto product)
        {
            decimal baseCost = 25.00m;
            if (product.Price > 3000)
            {
                return baseCost + (product.Price * 0.01m);
            }
            return baseCost;
        }
    }
}
