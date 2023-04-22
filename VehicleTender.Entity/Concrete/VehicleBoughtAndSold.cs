using System;

namespace VehicleTender.Entity.Concrete
{
    public class VehicleBoughtAndSold : BaseEntity
    {
        public int VehicleId { get; set; }
        public int BoughtId { get; set; }
        public int SoldId { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Vehicle Vehicle { get; set; }
        public User User{ get; set; }

    }
}
