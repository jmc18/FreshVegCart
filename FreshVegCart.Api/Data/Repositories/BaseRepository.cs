using FreshVegCart.Api.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreshVegCart.Api.Data.Repositories;

public class BaseRepository<T>(FreshVegCartDbContext dbContext) : IAsyncRepository<T> where T : class
{
    //private readonly FreshVegCartDbContext _dbContext = dbContext;

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<T?> GetByIdAsync(string id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<T?> GetByIdAsync(long id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        dbContext.Set<T>().Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteListAsync(List<T> entities)
    {
        dbContext.Set<T>().RemoveRange(entities);
        await dbContext.SaveChangesAsync();
    }
}