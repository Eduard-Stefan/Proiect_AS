using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class RamShippingCalculator : IShippingCalculator
    {
        // Offers completely free shipping if the total value is over 500 or the quantity is 4 or more; otherwise, a flat fee applies.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            if ((product.Price * quantity) > 500 || quantity >= 4)
            {
                return 0.00m;
            }

            return 15.00m;
        }
    }
}
