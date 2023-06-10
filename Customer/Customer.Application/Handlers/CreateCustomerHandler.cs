namespace Customer.Application.Handlers;
public class CreateCustomerHandler :
    IRequestHandler<CreateCustomerCommand, Customer.Domain.Entities.CustomerAggregate.Customer?>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Domain.Entities.CustomerAggregate.Customer?> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerCommandValidator validator = new(_customerRepository);
        var result = await validator.ValidateAsync(request, cancellationToken);

        if (result.IsValid)
        {
            var customer = new Customer.Domain.Entities.CustomerAggregate.Customer(
                request.FirstName,
                request.LastName,
                request.DateOfBirth,
                request.PhoneNumber,
                request.Email,
                request.BankAccountNumber
                );

            return _customerRepository.Insert(customer);
        }
        else
        {
            foreach (var error in result.Errors)
                Console.WriteLine($"Error inserting customer: {error.ErrorCode} - {error.ErrorMessage}");

            return null;
        }
    }
}
