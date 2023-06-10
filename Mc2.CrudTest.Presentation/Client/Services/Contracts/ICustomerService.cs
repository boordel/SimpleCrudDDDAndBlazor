using Mc2.CrudTest.Presentation.Shared.Dtos;

namespace Mc2.CrudTest.Presentation.Client.Services.Contracts;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>?> GetCustomers();
    Task<CustomerDto?> GetCustomerById(int id);
    Task<bool> AddCustomer(CustomerDto customer);
    Task<bool> UpdateCustomer(CustomerDto customer);
    Task<bool> DeleteCustomer(int id);
}
