using CustomerMinimalApiWS.Models;
using FluentValidation;

namespace CustomerMinimalApiWS.Validation;

public class CustomerValidation : AbstractValidator<CustomerDto>
{
    public CustomerValidation()
    {
        RuleFor(name => name.Forename).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(name => name.Surname).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(dob => dob.DateOfBirth).NotEmpty();
    }
}
