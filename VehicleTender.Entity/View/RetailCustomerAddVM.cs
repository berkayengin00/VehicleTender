using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;

namespace VehicleTender.Entity.View
{
	public class RetailCustomerAddVM
	{
		[DisplayName("Ad")]
		public string FirstName { get; set; }
		[DisplayName("Soyad")]
		public string LastName { get; set; }
		[StringLength(11, ErrorMessage = "Sadece 11 karakter giriniz", MinimumLength = 11)]
		[DisplayName("Telefone Numarası")]
		public string PhoneNumber { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("Parola")]
		public string PasswordHash { get; set; }
		[DisplayName("Parola Tekrarı")]
		[Compare("PasswordHash", ErrorMessage = "Parola uyuşmuyor!!!")]
		public string PasswordHashAgain { get; set; }
		[DisplayName("Email Doğrulaması")]
		public bool IsVerify { get; set; }
		[DisplayName("Aktif Mi?")]
		public bool IsActive { get; set; }
		public int CreatedBy { get; set; }
		public int UpdatedBy { get; set; }
		public DateTime AddedDate { get; set; }=DateTime.Now;
		public DateTime UpdatedDate { get; set; }=DateTime.Now;
		
		
	}
}