using System;

namespace VehicleTender.Entity.Concrete
{
    public class VehicleStatusHistory : BaseEntity
    {
        public int VehicleId { get; set; }
        public int VehicleStatusId { get; set; }
        public DateTime StatusChangeDate { get; set; }
        public Vehicle Vehicle { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
    }
}
