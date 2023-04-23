using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleTender.Entity.Concrete;

namespace VehicleTender.Entity.View
{
	public class TenderAddVMForAdmin
	{
		[DisplayName("İhale Adı")]
		public string TenderName { get; set; }
		[DisplayName("İhale Durumu")]
		public int TenderStatusId { get; set; }
		[DisplayName("İhale Başlangıç Tarihi")]
		public DateTime StartDateTime { get; set; }
		[DisplayName("İhale Bitiş Tarihi")]
		public DateTime EndDateTime { get; set; }
		[DisplayName("İhale Türü")]
		public int TenderTypeId { get; set; }
		[DisplayName("Başlangıç Fiyatı")]
		public decimal StartPrice { get; set; }
		[DisplayName("Minimum Fiyat")]
		public decimal MinPrice { get; set; }
		[DisplayName("Şirket Adı")]
		public int CorporateId { get; set; }

		public List<SelectListItem> TenderTypes { get; set; }
		public List<SelectListItem> CompanyNames { get; set; }
	}
}
