using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class MotherboardShippingCalculator : IShippingCalculator
    {
        // Applies a base rate, an anti-shock packaging fee for premium boards, and a 15% bulk discount for 3 or more units.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            decimal baseCost = 25.00m * quantity;
            decimal antiShockPackaging = product.Price > 1000 ? 15.00m * quantity : 0;

            decimal totalCost = baseCost + antiShockPackaging;

            return quantity >= 3 ? totalCost * 0.85m : totalCost;
        }
    }
}
