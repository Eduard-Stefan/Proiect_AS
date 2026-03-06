using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCGalaxy.Server.Dtos;
using PCGalaxy.Server.Services.Interfaces;

namespace PCGalaxy.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController(IProductService productService) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var products = await productService.GetAllAsync();
			return Ok(products);
		}

		[HttpGet("category/{categoryId:int}")]
		public async Task<IActionResult> GetAllByCategoryAsync(int categoryId)
		{
			var products = await productService.GetAllByCategoryAsync(categoryId);
			return Ok(products);
		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetByIdAsync(Guid id)
		{
			var product = await productService.GetByIdAsync(id);
			if (product == null)
			{
				return NotFound();
			}

			return Ok(product);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] ProductDto product)
		{
			await productService.CreateAsync(product);
			return Ok(product);
		}

		[Authorize(Roles = "admin")]
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ProductDto product)
		{
			if (id != product.Id)
			{
				return BadRequest("The ID in the URL does not match the ID in the request body.");
			}

			await productService.UpdateAsync(product);
			return Ok(product);
		}

		[Authorize(Roles = "admin")]
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var product = await productService.GetByIdAsync(id);
			if (product == null)
			{
				return NotFound();
			}

			await productService.DeleteAsync(product);
			return NoContent();
		}
	}
}
