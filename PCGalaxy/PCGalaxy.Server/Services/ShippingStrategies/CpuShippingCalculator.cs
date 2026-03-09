using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public class CpuShippingCalculator : IShippingCalculator
    {
        // Charges a standard per-unit fee plus a flat secure transport surcharge if the total value exceeds 5000.
        public decimal CalculateShippingCost(ProductDto product, int quantity)
        {
            decimal standardShipping = 15.00m * quantity;

            decimal totalValue = product.Price * quantity;
            decimal secureTransportSurcharge = totalValue > 5000 ? 75.00m : 0;

            return standardShipping + secureTransportSurcharge;
        }
    }
}
