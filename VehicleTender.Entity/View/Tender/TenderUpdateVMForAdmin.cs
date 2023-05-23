using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.Enum;

namespace VehicleTender.Entity.View.Tender
{
	public class TenderUpdateVMForAdmin
	{
		// todo ihale eklerken şirket seçilirse ihale o şirketin üstüne mi açılacak yoksa sadece araç seçimi için mi şirket seçimi yapılacak
		// todo eğer öyleyse bireysel seçilirse ne yapılcak
		// eğer hem bireyselde hemde kurumsal seçiminde birisi seçilecek ise id kolonu eklenecek 
		//  kruumsal seçiminin amacı sadece hem kruumasl olması hemde o şirketin araçlarından seçmek ise ve bu adın tutulması gerekmiyor ise herhangi bir eklemeye gerek yok
		public int TenderId { get; set; }
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
		//[DisplayName("Şirket Adı")]
		//public int CorporateId { get; set; }
		public DateTime AddedDateTime { get; set; }
		public DateTime ModefieDateTime { get; set; } = DateTime.Now;
		public int UpdatedById { get; set; }
		public bool IsActive { get; set; } = true;

		public List<TenderDetailVM> TenderDetailList { get; set; }
		public List<SelectListItem> TenderTypes { get; set; }
		//public List<SelectListItem> CompanyNames { get; set; }
		public List<SelectListItem> TenderStatusList { get; set; }
	}
}
