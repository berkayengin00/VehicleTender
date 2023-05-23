using System;

namespace VehicleTender.Entity.Concrete
{
    public class Vehicle : BaseEntity
    {
	    public int UserId { get; set; }
	    public string LicensePlate { get; set; }
        public short VehicleYear { get; set; }
        public string Version { get; set; }
        public int KiloMeter { get; set; }
        public string Description { get; set; }
        public int GearTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int BodyTypeId { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public GearType GearType { get; set; }
        public FuelType FuelType { get; set; }
        public BodyType BodyType { get; set; }
        public Model Model { get; set; }
        public Color Color { get; set; }
        public User User { get; set; }
    }
}
