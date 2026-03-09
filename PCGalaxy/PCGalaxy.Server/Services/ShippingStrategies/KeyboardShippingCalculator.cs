using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class KeyboardShippingCalculator : IShippingCalculator
    {
        // Calculates a per-unit cost and adds a single, fixed odd-shape surcharge for the entire order.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            decimal perUnitCost = 10.00m * quantity;
            decimal oddShapeSurcharge = 15.00m;

            return perUnitCost + oddShapeSurcharge;
        }
    }
}
