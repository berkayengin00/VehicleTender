using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace VehicleTender.Entity.View
{
	public class NotaryFeeVM
	{
		public int Id { get; set; }

		[DisplayName("Komisyon Ücreti")]
		[Range(0,10000000,ErrorMessage = "Komisyon 0 ile 10000000 arasında olmalıdır ")]
		public decimal Fee { get; set; }

		[DisplayName("Başlangıç Tarihi")]
		public DateTime StartDate { get; set; }

		[DisplayName("Bitiş Tarihi")]
		public DateTime EndDate { get; set; }

		public bool IsActive { get; set; } = true;
	}
}
