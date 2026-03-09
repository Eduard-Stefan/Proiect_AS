using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class GpuShippingCalculator : IShippingCalculator
    {
        // Calculates a base cost plus a progressive insurance rate based on the individual GPU price.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            decimal baseCost = 30.00m * quantity;
            decimal totalValue = product.Price * quantity;

            decimal insuranceRate = product.Price < 4000 ? 0.01m : 0.025m;
            decimal insuranceCost = totalValue * insuranceRate;

            return baseCost + insuranceCost;
        }
    }
}
