namespace VehicleTender.Entity.Concrete
{
    public class Model : BaseEntity
    {
        public string ModelName { get; set; }
        public int BrandId { get; set; }

        public Brand Brand { get; set; }
    }
}
