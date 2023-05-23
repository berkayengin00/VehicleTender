using System;

namespace VehicleTender.Entity.Concrete
{
    public class TenderHistory : BaseEntity
    {
       public int TenderDetailId { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDate { get; set; }

        public TenderDetail TenderDetail { get; set; }
        public User User { get; set; }


    }
}
