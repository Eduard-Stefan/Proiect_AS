using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class HeadsetShippingCalculator : IShippingCalculator
    {
        // Simulates carrier rules by applying the higher cost between standard weight and dimensional weight.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            decimal baseWeightCost = 15.00m;
            decimal dimensionalWeightCost = 22.00m;

            decimal highestCostMethod = baseWeightCost > dimensionalWeightCost ? baseWeightCost : dimensionalWeightCost;

            return highestCostMethod * quantity;
        }
    }
}
