using CustomerSupplier.WebApi.Dto;
using CustomerSupplier.WebApi.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CustomerSupplier.WebApi.Configurations.DependenceInjection
{
    public static class ValidationConfiguration
    {
        public static void ConfigureValidations(this IServiceCollection services)
        {
           services.AddFluentValidation();

           services.AddScoped<IValidator<CustomerSupplierDto>, CreateCustomerSupplierValidation>();
           services.AddScoped<IValidator<CustomerSupplierAddressDto>, CreateCustomerSupplierAddressValifation>();
           services.AddScoped<IValidator<CustomerSupplierContactDto>, CreateCustomerSupplierContactValidation>();
        }
    }
}
