namespace Customer.Application.Handlers;
public class GetCustomerByIdHandler : 
    IRequestHandler<GetCustomerByIdQuery, Customer.Domain.Entities.CustomerAggregate.Customer?>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Domain.Entities.CustomerAggregate.Customer?> Handle(
        GetCustomerByIdQuery request, CancellationToken cancellationToken) =>
        await _customerRepository.GetByIdAsync(request.Id);
}
