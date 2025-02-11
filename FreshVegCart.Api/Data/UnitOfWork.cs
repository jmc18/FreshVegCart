using FreshVegCart.Api.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace FreshVegCart.Api.Data;

public class UnitOfWork(FreshVegCartDbContext dbContext) : IUnitOfWork, IAsyncDisposable
{
    //private readonly FreshVegCartDbContext _dbContext = dbContext;
    private bool _disposed;

    public int SaveChanges()
    {
        return dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// The data is not used in this override but is there to be able to test the data that will be saved.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task<int> SaveChangesAsync<T>(T data)
    {
        return await dbContext.SaveChangesAsync();
    }

    public IDbContextTransaction BeginTransaction()
    {
        return dbContext.Database.BeginTransaction();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await dbContext.Database.BeginTransactionAsync();
    }
    protected async Task Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                dbContext.DisposeAsync();
            }
        }
        _disposed = true;
    }

    public async ValueTask DisposeAsync()
    {
        await Dispose(true);
        GC.SuppressFinalize(this);
    }
}
