using System.ComponentModel.DataAnnotations;

namespace PCGalaxy.Server.Dtos
{
	public class CategoryDto
	{
		public required int Id { get; set; }
		public string? Name { get; set; }
	}
}
