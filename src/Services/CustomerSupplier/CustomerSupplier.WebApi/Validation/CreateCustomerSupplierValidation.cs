using CustomerSupplier.WebApi.Dto;
using FluentValidation;

namespace CustomerSupplier.WebApi.Validation;

public class CreateCustomerSupplierValidation : AbstractValidator<CustomerSupplierDto>
{
    public CreateCustomerSupplierValidation()
    {
        RuleFor(cs => cs.Name).NotEmpty().NotNull().WithMessage("The name field is required {PropertyName}");

        RuleForEach(cs => cs.Addresses).SetValidator(new CreateCustomerSupplierAddressValifation());

        RuleForEach(cs => cs.Contacts).SetValidator(new CreateCustomerSupplierContactValidation());
    }
}