namespace Customer.Application.Handlers;
public class GetCustomerListHandler : 
    IRequestHandler<GetCustomerListQuery, IEnumerable<Customer.Domain.Entities.CustomerAggregate.Customer>?>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerListHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Domain.Entities.CustomerAggregate.Customer>?> Handle(
        GetCustomerListQuery request, CancellationToken cancellationToken) =>
        await _customerRepository.GetAllAsync();
}
