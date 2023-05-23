using System.ComponentModel.DataAnnotations;

namespace VehicleTender.Entity.View
{
	public class LoginVM
	{
		[EmailAddress(ErrorMessage = "Email adresi geçerli değil")]
		public string Email { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
