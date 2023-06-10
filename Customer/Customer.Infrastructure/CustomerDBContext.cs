using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure;
public class CustomerDBContext: DbContext
{
	DbSet<Customer.Domain.Entities.CustomerAggregate.Customer> Customers { get; set; }

	public CustomerDBContext(DbContextOptions<CustomerDBContext> options): base(options) { }
}
