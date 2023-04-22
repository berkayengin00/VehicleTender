namespace VehicleTender.Entity.Concrete
{
    public class CorporateCustomer:User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string CompanyType { get; set; }
    }
}
