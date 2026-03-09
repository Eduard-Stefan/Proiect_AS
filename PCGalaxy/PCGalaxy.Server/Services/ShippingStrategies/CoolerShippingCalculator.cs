using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class CoolerShippingCalculator : IShippingCalculator
    {
        // Uses a logarithmic scale (square root) to dynamically reduce the cost per unit as quantity increases.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            decimal baseCost = 20.00m;

            decimal scaleFactor = (decimal)Math.Sqrt(quantity);

            return Math.Round(baseCost * scaleFactor, 2);
        }
    }
}
