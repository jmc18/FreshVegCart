namespace FreshVegCart.Api.Interfaces.Persistence.Repositories;

public interface IAsyncRepository<T> where T : class
{
    public Task<T?> GetByIdAsync(Guid id);
    public Task<T?> GetByIdAsync(string id);
    public Task<T?> GetByIdAsync(int id);
    public Task<IReadOnlyList<T>> ListAllAsync();
    public Task<T> AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
    Task DeleteListAsync(List<T> entities);
}