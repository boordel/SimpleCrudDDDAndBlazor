using FluentValidation;

namespace Customer.Application.Handlers;
public class UpdateCustomerByIdHandler :
    IRequestHandler<UpdateCustomerByIdCommand, Customer.Domain.Entities.CustomerAggregate.Customer?>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerByIdHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Domain.Entities.CustomerAggregate.Customer?> Handle(UpdateCustomerByIdCommand request, CancellationToken cancellationToken)
    {
        UpdateCustomerByIdCommandValidator validator = new();
        var result = await validator.ValidateAsync(request, cancellationToken);

        if (result.IsValid)
        {
            var customer = new Customer.Domain.Entities.CustomerAggregate.Customer(
                request.Id,
                request.FirstName,
                request.LastName,
                request.DateOfBirth,
                request.PhoneNumber,
                request.Email,
                request.BankAccountNumber
                );

            return _customerRepository.Update(customer);
        }
        else
        {
            foreach (var error in result.Errors)
                Console.WriteLine($"Error updating customer: {error.ErrorCode} - {error.ErrorMessage}");

            return null;
        }
    }
}
