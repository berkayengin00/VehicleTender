using System;

namespace VehicleTender.Entity.Concrete
{
    public class BuyNow : BaseEntity
    {
        public int VehicleId { get; set; }
        public string AdvertName { get; set; }
        public string AdvertDescription { get; set; }
        public decimal Price { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Vehicle Vehicle { get; set; }
        public User User { get; set; }
    }
}
