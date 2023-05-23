using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VehicleTender.Entity.Enum;

namespace VehicleTender.Entity.View
{
	public class CorporateCustomerAddVM
	{
		
		[DisplayName("Ad")]
		public string FirstName { get; set; }
		[DisplayName("Soyad")]
		public string LastName { get; set; }
		[DisplayName("Telefone Numarası")]
		[StringLength(11, ErrorMessage = "Sadece 11 karakter giriniz", MinimumLength = 11)]
		public string PhoneNumber { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("Email Doğrulaması")]
		public bool IsVerify { get; set; }
		[DisplayName("Şirket Adı")]
		public string CompanyName { get; set; }
		[DisplayName("İl")]
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Lütfen İl seçiniz")]
		public int Province { get; set; }
		[DisplayName("İlçe")]
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Lütfen ilçe seçiniz")]
		public int District { get; set; }
		[DisplayName("Adres")]
		public string Neighbourhood { get; set; }
		[DisplayName("Şirket Türü")]
		public string CompanyType { get; set; }
		[DisplayName("Parola")]
		public string PasswordHash { get; set; }
		[Compare("PasswordHash", ErrorMessage = "Parola uyuşmuyor!!!")]
		[DisplayName("Parola Tekrar")]
		public string PasswordHashAgain { get; set; }
		[DisplayName("Aktif Mi?")]
		public bool IsActive { get; set; }=true;
		public int CreatedBy { get; set; }
		public int UpdatedBy { get; set; }
		public DateTime AddedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
		public int CorporatePackageId { get; set; } = (int)CorporateCustomerPackageType.PaketTanımlanmasıYapılmadı;

		public ProvinceAndDistrictForCache CacheList { get; set; }
	}
}
