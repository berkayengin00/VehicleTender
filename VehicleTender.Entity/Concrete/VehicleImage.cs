namespace VehicleTender.Entity.Concrete
{
    public class VehicleImage : BaseEntity
    {
        public int VehicleId { get; set; }
        public string ImagePath { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
