namespace PCGalaxy.Server.Services.Interfaces
{
    public interface IShippingService
    {
        Task<decimal> CalculateTotalShippingForUserAsync(string userId);
    }
}
