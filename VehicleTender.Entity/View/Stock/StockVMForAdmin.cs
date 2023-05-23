using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View.Stock
{
	public class StockVMForAdmin
	{
		public string LicensePlate { get; set; }
		public decimal AddedPrice { get; set; }
		public decimal PreliminaryValuationPrice { get; set; }
		public DateTime AddedDate { get; set; }
	}
}
