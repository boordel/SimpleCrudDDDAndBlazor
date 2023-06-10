namespace Customer.Application.Queries;
public record GetCustomerByIdQuery(int Id): IRequest<Customer.Domain.Entities.CustomerAggregate.Customer?>;
