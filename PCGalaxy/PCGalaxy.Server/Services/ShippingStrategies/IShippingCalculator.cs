using PCGalaxy.Server.Dtos;

namespace PCGalaxy.Server.Services.ShippingStrategies
{
    public interface IShippingCalculator
    {
        decimal CalculateShippingCost(ProductDto product);
    }
}
