using System;

namespace VehicleTender.Entity.Concrete
{
    public class Stock : BaseEntity
    {
        public int VehicleId { get; set; }
        public int UserId { get; set; }//kime ait
        public decimal PreliminaryValuationPrice { get; set; }
        public decimal AddedPrice { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Vehicle Vehicle { get; set; }
        public User User { get; set; }

    }
}
