using Microsoft.AspNetCore.Mvc;
using PCGalaxy.Server.Services.Interfaces;
using PCGalaxy.Server.ViewModels;

namespace PCGalaxy.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController(IAccountService accountService) : ControllerBase
	{
		[HttpPost("register")]
		public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
		{
			var result = await accountService.RegisterAsync(model);

			if (result.Succeeded)
			{
				return Ok(model);
			}

			return BadRequest(result);
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
		{
			var result = await accountService.SignInAsync(model);

			if (result.Succeeded)
			{
				return Ok(model);
			}

			return Unauthorized("Invalid login attempt.");
		}

		[HttpPost("logout")]
		public async Task<IActionResult> LogoutAsync()
		{
			await accountService.SignOutAsync();
			return Ok();
		}

		[HttpGet("is-signed-in")]
		public IActionResult IsSignedIn()
		{
			return Ok(accountService.IsSignedIn());
		}

		[HttpGet("current-user")]
		public async Task<IActionResult> GetCurrentUserAsync()
		{
			return Ok(await accountService.GetCurrentUserAsync());
		}

		[HttpGet("current-user/role")]
		public async Task<IActionResult> GetCurrentUserRoleAsync()
		{
			return Ok(await accountService.GetCurrentUserRoleAsync());
		}
	}
}
