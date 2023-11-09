namespace CustomerSupplier.Domain.Entities
{
    public class CustomerSupplier
    {
        private List<CustomerSupplierContact> _contactList;
        private List<CustomerSupplierAddress> _addressList;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyCollection<CustomerSupplierContact> ContactList => _contactList;
        public IReadOnlyCollection<CustomerSupplierAddress> AddressList => _addressList;

        public CustomerSupplier(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _contactList = new List<CustomerSupplierContact>();
            _addressList = new List<CustomerSupplierAddress>();
        }

        public void AddContact(string email, string phone)
        {
            CustomerSupplierContact contact = new CustomerSupplierContact(email, phone);
            _contactList.Add(contact);
        }

        public void AddAddress(string road, string district, string city, string state)
        {
            CustomerSupplierAddress address = new CustomerSupplierAddress(road, district, city, state);
            _addressList.Add(address);
        }

        public void UpdateCustomerSupplier(string name)
        {
            Name = name;
        }
    }
}
