using System;

namespace VehicleTender.Entity.Concrete
{
    public class CommissionFee:BaseEntity
    {
        public decimal Fee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal VehicleMinPrice { get; set; }
        public decimal VehicleMaxPrice { get; set; }
    }
}
