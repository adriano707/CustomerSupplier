namespace CustomerSupplier.WebApi.Dto
{
    public class CustomerSupplierCreateDto
    {
        public string Name { get; set; }
        //Contact
        public string Email { get; set; }
        public string Phone { get; set; }
        //Address
        public string Road { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
