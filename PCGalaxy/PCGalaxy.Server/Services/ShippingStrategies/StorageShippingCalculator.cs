using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class StorageShippingCalculator : IShippingCalculator
    {
        // Charges a flat rate for the first 2 units and adds an extra weight penalty for every additional unit.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            decimal baseCost = 15.00m;

            decimal extraWeightFee = quantity > 2 ? (quantity - 2) * 5.00m : 0;

            return baseCost + extraWeightFee;
        }
    }
}
