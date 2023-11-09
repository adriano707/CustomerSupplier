namespace CustomerSupplier.Domain.Entities
{
    public class CustomerSupplierAddress
    {
        public int Id { get; set; }
        public int CustomerSupplierId { get; set; }
        public string Road { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public CustomerSupplierAddress()
        {
            
        }

        public CustomerSupplierAddress(string road, string district, string city, string state)
        {
            Road = road ?? throw new ArgumentNullException(nameof(road));
            District = district ?? throw new ArgumentNullException(nameof(district));
            City = city ?? throw new ArgumentNullException(nameof(city));
            State = state ?? throw new ArgumentNullException(nameof(state));
        }

        public void UpdateCustomerSupplierAddress(string road, string district, string city, string state)
        {
            Road = road;
            District = district;
            City = city;
            State = state;
        }
    }
}
