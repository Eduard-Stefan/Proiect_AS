using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class PowerSupplyShippingCalculator : IShippingCalculator
    {
        // Applies a per-unit fee, simulates heavy weight based on a percentage of the price, and adds a fixed fuel surcharge.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            decimal weightSimulationFee = (product.Price * 0.03m) * quantity;
            decimal fixedFuelSurcharge = 10.00m;

            return 20.00m * quantity + weightSimulationFee + fixedFuelSurcharge;
        }
    }
}
