using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.Concrete
{
	public class LogDetail : BaseEntity
	{
		public string Description { get; set; }
		public int LogTypeId { get; set; }
		public int UserId { get; set; }
		public LogType LogType { get; set; }
		public User User { get; set; }
	}
}
