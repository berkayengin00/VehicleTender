using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		public string UserName { get; set; }
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
