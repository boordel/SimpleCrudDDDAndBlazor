using Customer.Application.Commands;

namespace Customer.Application.Handlers;
public class DeleteCustomerByIdHandler : IRequestHandler<DeleteCustomerByIdCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerByIdHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken) =>
        await _customerRepository.DeleteByIdAsync(request.Id);
}
