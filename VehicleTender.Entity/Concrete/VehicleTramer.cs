using System;

namespace VehicleTender.Entity.Concrete
{
    public class VehicleTramer
    {
        public int VehicleId { get; set; }
        public int TramerId { get; set; }
        public DateTime AddedDate { get; set; }

        public Vehicle Vehicle { get; set; }
        public Tramer Tramer { get; set; }
    }
}
