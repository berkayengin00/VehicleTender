using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTender.Entity.Enum;

namespace VehicleTender.Entity.View
{
	public class TenderListVMForAdmin
	{

		public int TenderId { get; set; }
		[DisplayName("İhale Adı")]
		public string TenderName { get; set; }
		[DisplayName("İhale Durumu")]
		public string TenderStatusName { get; set; }
		[DisplayName("İhale Başlangıç Tarihi")]
		public DateTime StartDateTime { get; set; }
		[DisplayName("İhale Bitiş Tarihi")]
		public DateTime EndDateTime { get; set; }
		[DisplayName("İhale Türü")]
		public string TenderTypeName { get; set; }
		[DisplayName("İhale Silindi Mi?")]
		public bool IsActive { get; set; } = true;
	}
}
