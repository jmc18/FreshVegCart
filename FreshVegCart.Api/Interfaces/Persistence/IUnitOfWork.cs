using Microsoft.EntityFrameworkCore.Storage;

namespace FreshVegCart.Api.Interfaces.Persistence;

public interface IUnitOfWork
{


    int SaveChanges();
    /// <summary>
    /// Asynchronously saves all changes made in this context to the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Asynchronously saves changes to the data of type T.
    /// </summary>
    Task<int> SaveChangesAsync<T>(T data);

    /// <summary>
    /// Begins a database transaction.
    /// </summary>
    /// <returns>An object representing the new transaction.</returns>
    IDbContextTransaction BeginTransaction();

    /// <summary>
    /// Asynchronously begins a database transaction.
    /// </summary>
    /// <returns>A task that represents the asynchronous begin operation. The task result contains the object that represents the new transaction.</returns>
    Task<IDbContextTransaction> BeginTransactionAsync();
}