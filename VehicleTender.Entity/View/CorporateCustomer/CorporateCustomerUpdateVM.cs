using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View.CorporateCustomer
{
	public class CorporateCustomerUpdateVM
	{
		public int UserId { get; set; }
		[DisplayName("Ad")]
		public string FirstName { get; set; }
		[DisplayName("Soyad")]
		public string LastName { get; set; }
		[DisplayName("Telefone Numarası")]
		public string PhoneNumber { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("Email Doğrulaması")]
		public bool IsVerify { get; set; }
		[DisplayName("Şirket Adı")]
		public string CompanyName { get; set; }
		[DisplayName("İl")]
		public int ProvinceId { get; set; }
		[DisplayName("İlçe")]
		public int DistrictId { get; set; }
		[DisplayName("Adres")]
		public string Neighbourhood { get; set; }
		[DisplayName("Şirket Türü")]
		public string CompanyType { get; set; }
		[DisplayName("Parola")]
		public string PasswordHash { get; set; }
		[DisplayName("Aktif Mi?")]
		public bool IsActive { get; set; } = true;
		public int CreatedBy { get; set; }
		public int UpdatedBy { get; set; }
		public DateTime AddedDate { get; set; }
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
		public ProvinceAndDistrictForCache ListCache { get; set; }
	}
}
