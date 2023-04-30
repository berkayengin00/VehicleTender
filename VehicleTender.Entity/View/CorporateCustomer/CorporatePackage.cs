using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VehicleTender.Entity.View.CorporateCustomer
{
	public class CorporatePackageVM
	{
		public int Id { get; set; }
		public List<SelectListItem> packages { get; set; }
	}
}
