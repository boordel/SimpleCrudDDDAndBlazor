using Customer.Domain.SeedWorks;

namespace Customer.Application.Contracts;
public interface ICustomerRepository: IRepository<Customer.Domain.Entities.CustomerAggregate.Customer>
{
    bool IsEmailUnique(string email);
    bool IsCustomerUnique(string firstName, string lastName, string dateOfBirth);
}
