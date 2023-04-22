using System;

namespace VehicleTender.Entity.Concrete
{
    public class NotaryFee:BaseEntity
    {
        public decimal Fee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
