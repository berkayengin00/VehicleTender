using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View.CorporateCustomer
{
	public class CorporateCustomerListVMForAdmin
	{
		public int Id { get; set; }
		[DisplayName("Ad")]
		public string FirstName { get; set; }
		[DisplayName("Soyad")]
		public string LastName { get; set; }
		[DisplayName("Telefone Numarası")]
		public string PhoneNumber { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("Email Doğrulanı Mı?")]
		public bool IsVerify { get; set; }
		[DisplayName("Şirket Adı")]
		public string CompanyName { get; set; }
		[DisplayName("İlçe")]
		public string District { get; set; }
		[DisplayName("Şirket Türü")]
		public string CompanyType { get; set; }
		[DisplayName("Aktif Mi?")]
		public bool IsActive { get; set; }
		[DisplayName("Eklenme Tarihi")]
		public DateTime AddedDate { get; set; }
		public string PackageName { get; set; }
		public int PackageId { get; set; }
	}
}
