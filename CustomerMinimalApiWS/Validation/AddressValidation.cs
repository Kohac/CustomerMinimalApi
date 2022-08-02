using CustomerMinimalApiWS.Models;
using FluentValidation;

namespace CustomerMinimalApiWS.Validation;

public class AddressValidation : AbstractValidator<AddressDto>
{
    public AddressValidation()
    {
        RuleFor(x => x.PostalCode).NotNull();
    }
}
