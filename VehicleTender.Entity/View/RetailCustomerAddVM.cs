using System.ComponentModel;

namespace VehicleTender.Entity.View
{
	public class RetailCustomerAddVM
	{
		[DisplayName("Ad")]
		public string FirstName { get; set; }
		[DisplayName("Soyad")]
		public string LastName { get; set; }
		[DisplayName("Telefone Numarası")]
		public string PhoneNumber { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("Parola")]
		public string PasswordHash { get; set; }
		[DisplayName("Parola Tekrarı")]
		public string PasswordHashAgain { get; set; }
		[DisplayName("Email Doğrulaması")]
		public bool IsVerify { get; set; }
		[DisplayName("Aktif Mi?")]
		public bool IsActive { get; set; }
	}
}