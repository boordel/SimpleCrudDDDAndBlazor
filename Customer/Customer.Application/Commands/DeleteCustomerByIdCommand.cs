namespace Customer.Application.Commands;
public record DeleteCustomerByIdCommand(int Id): IRequest<bool>;
