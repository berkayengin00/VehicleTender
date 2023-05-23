using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.Concrete
{
	public class Province:BaseEntity
	{
		public string Name { get; set; }
	}

	public class District : BaseEntity
	{
		public string Name { get; set; }
		public int ProvinceId { get; set; }
		public Province Province { get; set; }
	}
}
