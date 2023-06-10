using PhoneNumbers;

namespace Customer.Application.Commands;
public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator(ICustomerRepository customerRepository)
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("FirstName can not be empty")
            .MaximumLength(50).WithMessage("FirstName max lenght is 50");

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("LastName can not be empty")
            .MaximumLength(50).WithMessage("LastName max lenght is 50");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email can not be empty")
            .EmailAddress().WithMessage("Email must have valid format")
            .Custom((val, context) =>
            {
                if (!customerRepository.IsEmailUnique(val))
                    context.AddFailure("Email", "A customer with this email already exists");
            });

        RuleFor(c => c.BankAccountNumber)
            .Custom((val, context) =>
            {
                // Check bank account format, I dont know which format is expected
            });

        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber can not be empty")
            .Custom((val, context) =>
            {
                // Validate PhoneNumber based on google LibPhoneNumber
                var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                var parsedNumber = phoneNumberUtil.Parse(val, null);
                if (!phoneNumberUtil.IsValidNumber(parsedNumber))
                    context.AddFailure("PhoneNumber", "PhoneNumber is not valid");
            });
    }
}
