using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View
{
	public class NotaryFeeVM
	{
		public int Id { get; set; }
		[DisplayName("Komisyon Ücreti")]
		public decimal Fee { get; set; }
		[DisplayName("Başlangıç Tarihi")]
		public DateTime StartDate { get; set; }
		[DisplayName("Bitiş Tarihi")]
		public DateTime EndDate { get; set; }

		public bool IsActive { get; set; } = true;
	}
}
