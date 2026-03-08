using PCGalaxy.Server.Services.Interfaces;
using PCGalaxy.Server.Services.ShippingStrategies;

namespace PCGalaxy.Server.Services
{
    public class ShippingService(ICartItemService cartItemService) : IShippingService
    {
        public async Task<decimal> CalculateTotalShippingForUserAsync(string userId)
        {
            var cartItems = await cartItemService.GetAllByUserIdAsync(userId);
            decimal totalShipping = 0;
            var factory = new ShippingCalculatorFactory();

            foreach (var item in cartItems)
            {
                if (item.Product?.Category != null)
                {
                    var categoryName = item.Product.Category.Name ?? string.Empty;
                    var calculator = factory.GetCalculator(categoryName);

                    totalShipping += calculator.CalculateShippingCost(item.Product, item.Quantity);
                }
            }

            return totalShipping;
        }
    }
}
