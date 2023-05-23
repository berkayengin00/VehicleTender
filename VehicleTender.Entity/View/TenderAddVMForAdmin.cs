using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.Enum;

namespace VehicleTender.Entity.View
{
	public class TenderAddVMForAdmin
	{
		[DisplayName("İhale Adı")]
		[StringLength(50,ErrorMessage = "İhale Adı 50 karakterden fazla olamaz.")]
		public string TenderName { get; set; }
		[DisplayName("İhale Durumu")]
		public int TenderStatusId { get; set; } = (int)(TenderStatusType.Baslamadi);
		[DisplayName("İhale Başlangıç Tarihi")]
		public DateTime StartDateTime { get; set; }
		[DisplayName("İhale Bitiş Tarihi")]
		public DateTime EndDateTime { get; set; }
		[DisplayName("İhale Türü")]
		public int TenderTypeId { get; set; }
		[DisplayName("Şirket Adı")]
		public int CorporateId { get; set; }
		public DateTime AddedDateTime { get; set; }=DateTime.Now;
		public DateTime ModefieDateTime { get; set; }=DateTime.Now;
		public int CreatedById { get; set; }
		public int UpdatedById { get; set; }
		public bool IsActive { get; set; }=true;
		

		public List<SelectListItem> TenderTypes { get; set; }
		public List<SelectListItem> CompanyNames { get; set; }
	}
}
