using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class PcCaseShippingCalculator : IShippingCalculator
    {
        // Enforces a strict, un-discountable volumetric fee per unit due to the massive box size.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            decimal volumetricFee = 60.00m;

            return volumetricFee * quantity;
        }
    }
}
