using System.ComponentModel.DataAnnotations;

namespace PCGalaxy.Server.ViewModels
{
	public class LoginViewModel
	{
		[EmailAddress]
		public required string Email { get; set; }

		[DataType(DataType.Password)]
		public required string Password { get; set; }

		public required bool RememberMe { get; set; }
	}
}
