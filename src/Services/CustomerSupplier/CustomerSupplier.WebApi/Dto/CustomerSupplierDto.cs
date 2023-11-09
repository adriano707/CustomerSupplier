namespace CustomerSupplier.WebApi.Dto;

public class CustomerSupplierDto
{
    public string Name { get; set; }
    public List<CustomerSupplierContactDto> Contacts { get; set; }
    public List<CustomerSupplierAddressDto> Addresses { get; set; }
}