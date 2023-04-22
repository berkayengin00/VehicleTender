using System;

namespace VehicleTender.Entity.Concrete
{
    public class TenderHistory : BaseEntity
    {
        public int TenderId { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDate { get; set; }

        public Tender Tender { get; set; }
        public User User { get; set; }


    }
}
