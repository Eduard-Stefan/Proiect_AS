using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class MonitorShippingCalculator : IShippingCalculator
    {
        // Combines a base cost with a 5% fragility insurance, plus a flat pallet surcharge for commercial quantities (5 or more).
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            decimal baseCost = 35.00m * quantity;
            decimal fragilityInsurance = (product.Price * 0.05m) * quantity;

            decimal totalCost = baseCost + fragilityInsurance;

            if (quantity >= 5)
            {
                totalCost += 150.00m;
            }

            return Math.Round(totalCost, 2);
        }
    }
}
