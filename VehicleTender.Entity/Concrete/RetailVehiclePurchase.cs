using System;

namespace VehicleTender.Entity.Concrete
{
    public class RetailVehiclePurchase : BaseEntity
    {
        public int VehicleId { get; set; }
        public int RetailVehiclePurchaseStatusId { get; set; }
        public decimal PreliminaryValuationPrice { get; set; }
        public decimal QuotedPrice { get; set; }
        public int SoldId { get; set; } // şirket aldığı için satın alan id ye gerek yok
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Vehicle Vehicle { get; set; }
        public RetailVehiclePurchaseStatus RetailVehiclePurchaseStatus { get; set; }
        public User User { get; set; }
    }
}
