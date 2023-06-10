using Customer.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Repositories;
public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDBContext _context;

    public CustomerRepository(CustomerDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Domain.Entities.CustomerAggregate.Customer>?> GetAllAsync() =>
        await _context
            .Set<Domain.Entities.CustomerAggregate.Customer>()
            .ToListAsync();

    public async Task<Domain.Entities.CustomerAggregate.Customer?> GetByIdAsync(int id) =>
        await _context
            .Set<Domain.Entities.CustomerAggregate.Customer>()
            .FirstOrDefaultAsync(c => c.Id == id);

    public Domain.Entities.CustomerAggregate.Customer? Insert(Domain.Entities.CustomerAggregate.Customer entity)
    {
        if (IsEmailUnique(entity.Email) &&
            IsCustomerUnique(entity.FirstName, entity.LastName, entity.DateOfBirth))
        {
            var customer = _context
                .Set<Domain.Entities.CustomerAggregate.Customer>()
                .Add(entity)
                .Entity;
            _context.SaveChanges();

            return customer;
        }
        else
            return null;
    }

    public Domain.Entities.CustomerAggregate.Customer Update(Domain.Entities.CustomerAggregate.Customer entity)
    {
        if (IsEmailStillUnique(entity.Id, entity.Email) &&
            IsCustomerStillUnique(entity.Id, entity.FirstName, entity.LastName, entity.DateOfBirth))
        {
            var customer = _context
                .Set<Domain.Entities.CustomerAggregate.Customer>()
                .Update(entity)
                .Entity;

            _context.SaveChanges();

            return customer;
        }

        return entity;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var customer = await _context
                                .Set<Domain.Entities.CustomerAggregate.Customer>()
                                .SingleOrDefaultAsync(c => c.Id == id);

        if (customer != null)
        {
            _context
                .Set<Domain.Entities.CustomerAggregate.Customer>()
                .Remove(customer);

            _context.SaveChanges();

            return true;
        }
        else
            return false;
    }

    public bool IsEmailUnique(string email) =>
        !_context
        .Set<Domain.Entities.CustomerAggregate.Customer>()
        .Any(c => c.Email == email);

    public bool IsCustomerUnique(string firstName, string lastName, string dateOfBirth) =>
        !_context
        .Set<Domain.Entities.CustomerAggregate.Customer>()
        .Any(c => c.FirstName == firstName && c.LastName == lastName && c.DateOfBirth == dateOfBirth);

    private bool IsEmailStillUnique(int id, string email) =>
        !_context
        .Set<Domain.Entities.CustomerAggregate.Customer>()
        .Any(c => c.Id != id && c.Email == email);

    private bool IsCustomerStillUnique(int id, string firstName, string lastName, string dateOfBirth) =>
        !_context
        .Set<Domain.Entities.CustomerAggregate.Customer>()
        .Any(c => c.Id != id && c.FirstName == firstName && c.LastName == lastName && c.DateOfBirth == dateOfBirth);
}
