using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.Entity.Concrete
{
	public class FinishedTender:BaseEntity
	{
		public int TenderDetailId { get; set; }
		public int UserId { get; set; }
		public decimal MinPrice { get; set; }
		public decimal OfferPrice { get; set; }
		public DateTime AddedDateTime { get; set; }

		public TenderDetail TenderDetail { get; set; }
		public User User { get; set; }
	}
}
