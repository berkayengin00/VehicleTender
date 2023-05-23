namespace VehicleTender.Entity.Concrete
{
	public class TenderDetail:BaseEntity
	{
		public int TenderId { get; set; }
		public int VehicleId { get; set; }
		public decimal MinPrice { get; set; }
		public decimal StartPrice { get; set; }
		public Vehicle Vehicle { get; set; }
		public Tender Tender { get; set; }
	}
}