using CustomerSupplier.Domain.Entities;

namespace CustomerSupplier.Domain.Sesrvices
{
    public interface ICustomerSupplierService
    {
        Task<Entities.CustomerSupplier> GetCustomerSupplierById(int id);
        Task<List<Entities.CustomerSupplier>> GetAllCustomerSupplier();
        Task<Entities.CustomerSupplier> CreateCustomerSupplier(string name, List<(string email, string phone)> contacts, List<(string road, string district, string city, string state)> addresses);
        Task<Entities.CustomerSupplier> UpdateCustomerSupplier(int id, string name, List<(int id, string email, string phone)> contacts, List<(int id, string road, string district, string city, string state)> addresses);
        Task DeleteCustomerSupplier(int id);
    }
}
