namespace Customer.Domain.SeedWorks;
public interface IRepository<T> where T : IAggregateRoot
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>?> GetAllAsync();
    T? Insert(T entity);
    T Update(T entity);
    Task<bool> DeleteByIdAsync(int id);
}
