using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VehicleTender.Entity.View.Employee
{
	public class EmployeeAddVM
	{
		public int EmployeeId { get; set; }
		[DisplayName("Kullanıcı Adı")]
		[StringLength(100, ErrorMessage ="En az 3 harf olmalıdır",MinimumLength = 3)]
		public string UserName { get; set; }
		
		[DisplayName("Ad")]
		[StringLength(100, ErrorMessage = "En az 3 harf olmalıdır", MinimumLength = 3)]
		public string FirstName { get; set; }
		
		[DisplayName("Soyad")]
		[StringLength(100, ErrorMessage = "En az 2 harf olmalıdır")]
		public string LastName { get; set; }
		
		[DisplayName("Telefone Numarası")]
		[StringLength(11,ErrorMessage ="Sadece 11 karakter giriniz",MinimumLength = 11)]
		public string PhoneNumber { get; set; }

		[EmailAddress(ErrorMessage = "email düzgün girilmedi")]
		[DisplayName("Email")]
		public string Email { get; set; }
		
		[DisplayName("Parola")]
		[StringLength(4,ErrorMessage = "En az 4 karakter girilmelidir.")]
		public string PasswordHash { get; set; }

		[System.Web.Mvc.Compare("PasswordHash",ErrorMessage = "Parola uyuşmuyor!!!")]
		[DisplayName("Parola Tekrar")]
		public string PasswordHashAgain { get; set; }
		
		[DisplayName("Role Seçiniz")]
		public int RoleId { get; set; }
		[DisplayName("Aktif Mi?")]
		public bool IsActive { get; set; }=true;
		public bool IsVerify { get; set; }=true;
		public int CreatedBy { get; set; }
		public int UpdatedBy { get; set; }
		public DateTime AddedDate { get; set; } = DateTime.Now;
		public DateTime UpdatedDate { get; set; } = DateTime.Now;
		public List<SelectListItem> Roles { get; set; }
	}
}
