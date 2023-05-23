using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.View.DB
{
	public class TenderAndTenderDetailVmForAdmin
	{
		public TenderAddVMForAdmin TenderAddVmForAdmin { get; set; }

		public List<TenderDetailAddVMForAdmin> tenderDetailList { get; set; }

	}
}
