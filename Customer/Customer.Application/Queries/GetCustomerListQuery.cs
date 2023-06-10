namespace Customer.Application.Queries;
public record GetCustomerListQuery(): IRequest<IEnumerable<Customer.Domain.Entities.CustomerAggregate.Customer>?>;
