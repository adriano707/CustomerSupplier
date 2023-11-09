using CustomerSupplier.Domain.Entities;
using CustomerSupplier.Domain.Repository;

namespace CustomerSupplier.Domain.Sesrvices
{
    public class CustomerSupplierService : ICustomerSupplierService
    {
        private readonly IRepository _repository;

        public CustomerSupplierService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Entities.CustomerSupplier> GetCustomerSupplierById(int id)
        {
            var customerSupplier = _repository.Query<Entities.CustomerSupplier>().FirstOrDefault(c => c.Id == id);
            return customerSupplier;
        }

        public async Task<List<Entities.CustomerSupplier>> GetAllCustomerSupplier()
        {
            var customerSupplier = _repository.Query<Entities.CustomerSupplier>().ToList();
            return customerSupplier;
        }

        public async Task<Entities.CustomerSupplier> CreateCustomerSupplier(string name, List<(string email, string phone)> contacts, List<(string road, string district, string city, string state)> addresses)
        {
            Entities.CustomerSupplier customerSupplier = new Entities.CustomerSupplier(name);

            foreach (var contact in contacts)
            {
                customerSupplier.AddContact(contact.email, contact.phone);
            }

            foreach (var address in addresses)
            {
                customerSupplier.AddAddress(address.road, address.district, address.city, address.state);
            }

            await _repository.InsertAsync(customerSupplier);

            await _repository.SaveChangeAsync();

            return customerSupplier;
        }

        public async Task<Entities.CustomerSupplier> UpdateCustomerSupplier(int id, string name, List<(int id, string email, string phone)> contacts, List<(int id, string road, string district, string city, string state)> addresses)
        {
            var customerSupplier = _repository.Query<Entities.CustomerSupplier>().FirstOrDefault(e => e.Id == id);

            if (customerSupplier is not null)
            {
                AddOrUpdateCustomerSupplierContact(contacts, customerSupplier);

                AddOrUpdateCustomerSupplierAddress(addresses, customerSupplier);

                customerSupplier.UpdateCustomerSupplier(name);
                _repository.Update(customerSupplier);
                await _repository.SaveChangeAsync();
            }
            
            return customerSupplier;
        }

        private void AddOrUpdateCustomerSupplierAddress(List<(int id, string road, string district, string city, string state)> addresses, Entities.CustomerSupplier customerSupplier)
        {
            foreach (var address in addresses.Where(c => c.id > 0))
            {
                foreach (var addressSupplier in customerSupplier.AddressList)
                {
                    if (address.id == addressSupplier.Id)
                    {
                        addressSupplier.UpdateCustomerSupplierAddress(address.road, address.district, address.city,
                            address.state);
                    }
                }
            }

            foreach (var address in addresses.Where(c => c.id == 0))
            {
                customerSupplier.AddAddress(address.road, address.district, address.city, address.state);
            }
        }

        private void AddOrUpdateCustomerSupplierContact(List<(int id, string email, string phone)> contacts, Entities.CustomerSupplier customerSupplier)
        {
            foreach (var contact in contacts.Where(c => c.id > 0))
            {
                foreach (var contactSupplier in customerSupplier.ContactList)
                {
                    if (contact.id == contactSupplier.Id)
                    {
                        contactSupplier.UpdateCustomerSupplierContact(contact.email, contact.phone);
                    }
                }
            }

            foreach (var contact in contacts.Where(c => c.id == 0))
            {
                customerSupplier.AddContact(contact.email, contact.phone);
            }
        }

        public async Task DeleteCustomerSupplier(int id)
        {
            var customerSupplier = _repository.Query<Entities.CustomerSupplier>().FirstOrDefault(c => c.Id == id);

            if (customerSupplier != null)
            {
                _repository.Delete(customerSupplier);
                await _repository.SaveChangeAsync();
            }
        }
    }
}
