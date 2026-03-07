using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCGalaxy.Server.Services.Interfaces;

namespace PCGalaxy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController(IShippingService shippingService, IAccountService accountService) : ControllerBase
    {
        [HttpGet("calculate")]
        [Authorize]
        public async Task<IActionResult> CalculateShipping()
        {
            var user = await accountService.GetCurrentUserAsync();
            if (user == null)
            {
                return Unauthorized("You need to be logged in.");
            }

            var totalShipping = await shippingService.CalculateTotalShippingForUserAsync(user.Id!);

            return Ok(new { TotalShippingFee = totalShipping });
        }
    }
}
