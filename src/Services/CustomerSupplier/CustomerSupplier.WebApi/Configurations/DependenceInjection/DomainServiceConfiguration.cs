using CustomerSupplier.WebApi.Dto;
using CustomerSupplier.WebApi.Validation;
using FluentValidation.AspNetCore;
using FluentValidation;
using CustomerSupplier.Domain.Sesrvices;

namespace CustomerSupplier.WebApi.Configurations.DependenceInjection
{
    public static class DomainServiceConfiguration
    {
        public static void ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerSupplierService, CustomerSupplierService>();
        }
    }
}
