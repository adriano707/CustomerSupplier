using CustomerSupplier.WebApi.Dto;
using FluentValidation;

namespace CustomerSupplier.WebApi.Validation
{
    public class CreateCustomerSupplierAddressValifation : AbstractValidator<CustomerSupplierAddressDto> 
    {
        public CreateCustomerSupplierAddressValifation()
        {
            RuleFor(ca => ca.Road).NotNull().WithMessage("The Road is required {PropertyName}");
            RuleFor(ca => ca.District).NotNull().WithMessage("The district is required {PropertyName}");
            RuleFor(ca => ca.City).NotNull().WithMessage("The city is required {PropertyName}");
            RuleFor(ca => ca.State).NotNull().WithMessage("The state is required {PropertyName}");
        }
    }
}
