using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class FanShippingCalculator : IShippingCalculator
    {
        // Groups fans into shipping boxes of 4, charging a flat rate for each required box.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            int requiredBoxes = (int)Math.Ceiling(quantity / 4.0);

            return requiredBoxes * 15.00m;
        }
    }
}
