using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class MouseShippingCalculator : IShippingCalculator
    {
        // Waives the shipping fee entirely for premium mice; otherwise, charges a standard per-unit rate.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            if (product.Price >= 400)
            {
                return 0.00m;
            }

            return 15.00m * quantity;
        }
    }
}
