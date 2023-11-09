namespace CustomerSupplier.Domain.Entities
{
    public class CustomerSupplierContact
    {
        public int Id { get; set; }
        public int CustomerSupplierId { get; set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public CustomerSupplierContact()
        {
            
        }

        public CustomerSupplierContact(string email, string phone)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }

        public void UpdateCustomerSupplierContact(string email, string phone)
        {
            Email = email;
            Phone = phone;
        }
    }
}
