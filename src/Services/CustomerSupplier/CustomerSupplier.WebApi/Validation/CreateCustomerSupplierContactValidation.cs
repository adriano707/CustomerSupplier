using CustomerSupplier.WebApi.Dto;
using FluentValidation;

namespace CustomerSupplier.WebApi.Validation
{
    public class CreateCustomerSupplierContactValidation : AbstractValidator<CustomerSupplierContactDto>
    {
        public CreateCustomerSupplierContactValidation()
        {
            RuleFor(cc => cc.Email).NotNull().WithMessage("The email is required {PropertyName}");
            RuleFor(cc => cc.Phone).NotNull().WithMessage("The phone is required {PropertyName}");
        }
    }
}
