using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleTender.Entity.Concrete;
using VehicleTender.Entity.View.Vehicle;

namespace VehicleTender.Entity.View
{
	public class VehicleAddVMForAdmin
	{
		[DisplayName("Plaka")]
		public string LicensePlate { get; set; }
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
		public DateTime CreatedDate { get; set; }
		[DisplayName("Güncelleyen")]
		public int UpdatedBy { get; set; }
		[DisplayName("Güncelleme Tarihi")]
		public DateTime UpdatedDate { get; set; }
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
		[DisplayName("Bireysel/Kurumsal ?")]
		public int UserTypeId { get; set; }
		[DisplayName("Kullanıcı Seçiniz")]
		public int UserId { get; set; }
		
		public List<SelectListItem> UserTypeList { get; set; }
		public VehicleFeaturesForCache VehicleFeaturesForCache { get; set; }
	}
}
