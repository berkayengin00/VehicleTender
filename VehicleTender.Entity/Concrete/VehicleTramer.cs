using System;

namespace VehicleTender.Entity.Concrete
{
    public class VehicleTramer
    {
        public int VehicleId { get; set; }
        public int TramerId { get; set; }
        public int VehiclePartStatusId { get; set; }
        public DateTime AddedDate { get; set; }
        public decimal PartPrice { get; set; }

        public Vehicle Vehicle { get; set; }
        public Tramer Tramer { get; set; }
        public VehiclePartStatus VehiclePartStatus { get; set; }
    }
}
