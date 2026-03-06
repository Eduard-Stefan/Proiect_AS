using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PCGalaxy.Server.ViewModels
{
	public class RegisterViewModel : IValidatableObject
	{
		[StringLength(256, ErrorMessage = "The name must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
		public required string FirstName { get; set; }

		[StringLength(256, ErrorMessage = "The name must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
		public required string LastName { get; set; }

		[EmailAddress]
		public required string Email { get; set; }

		[Phone]
		public required string PhoneNumber { get; set; }

		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = "Passwords must be at least 6 characters.")]
		public required string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public required string ConfirmPassword { get; set; }

		private static readonly List<(string Regex, string ErrorMessage)> PasswordRules = new()
		{
			(@"\W", "Passwords must have at least one non alphanumeric character."),
			(@"\d", "Passwords must have at least one digit ('0'-'9')."),
			(@"[a-z]", "Passwords must have at least one lowercase ('a'-'z')."),
			(@"[A-Z]", "Passwords must have at least one uppercase ('A'-'Z').")
		};

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var matchTimeout = TimeSpan.FromMilliseconds(200);

			foreach (var (pattern, message) in PasswordRules)
			{
				if (!Regex.IsMatch(Password, pattern, RegexOptions.None, matchTimeout))
				{
					yield return new ValidationResult(message, new[] { nameof(Password) });
				}
			}
		}
	}
}
