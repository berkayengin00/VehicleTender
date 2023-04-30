using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View.DB
{
	public class DbVehicleAddVmForAdmin
	{
		[DisplayName("Model Yılı")]
		public short VehicleYear { get; set; }
		[DisplayName("Versiyon")]
		public string Version { get; set; }
		[DisplayName("Kilometre")]
		public int KiloMeter { get; set; }
		[DisplayName("Açıklama")]
		public string Description { get; set; }
		[DisplayName("Oluşturan")]
		public int CreatedBy { get; set; }
		[DisplayName("Oluşturulma Tarihi")]
		public DateTime CreatedDate { get; set; }=DateTime.Now;
		[DisplayName("Güncelleyen")]
		public int UpdatedBy { get; set; }
		[DisplayName("Güncelleme Tarihi")]
		public DateTime UpdatedDate { get; set; }=DateTime.Now;
		[DisplayName("Vites Tipi")]
		public int GearTypeId { get; set; }
		[DisplayName("Yakıt Tipi")]
		public int FuelTypeId { get; set; }
		[DisplayName("Kasa Tipi")]
		public int BodyTypeId { get; set; }
		[DisplayName("Model")]
		public int ModelId { get; set; }
		[DisplayName("Renk")]
		public int ColorId { get; set; }
		[DisplayName("Marka")]
		public int BrandId { get; set; }
		public bool IsActive { get; set; }=true;
		public string ImagePath { get; set; }
		public string LicensePlate { get; set; }
		public int UserId { get; set; }
		public int UserTypeId { get; set; }
	}
}
