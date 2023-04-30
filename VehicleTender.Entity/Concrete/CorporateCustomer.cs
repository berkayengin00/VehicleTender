using System;
using VehicleTender.Entity.Enum;

namespace VehicleTender.Entity.Concrete
{
    public class CorporateCustomer:User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public int DistrictId { get; set; }
        public string Neighbourhood { get; set; }
        public string CompanyType { get; set; }
        public int CorporatePackageId { get; set; } 

        public CorporatePackage CorporatePackage { get; set; }
        public District District { get; set; }
    }
}
