namespace Customer.Application.Commands;
public class UpdateCustomerByIdCommandValidator : AbstractValidator<UpdateCustomerByIdCommand>
{
    public UpdateCustomerByIdCommandValidator()
    {
        // Basic validation, must be completed
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("FirstName can not be empty")
            .MaximumLength(50).WithMessage("FirstName max lenght is 50");

        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("LastName can not be empty")
            .MaximumLength(50).WithMessage("LastName max lenght is 50");

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email can not be empty")
            .EmailAddress().WithMessage("Email must have valid format");
    }
}
