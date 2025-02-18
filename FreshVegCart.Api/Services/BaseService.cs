using AutoMapper;
using FreshVegCart.Api.Interfaces.Persistence;

namespace FreshVegCart.Api.Services;

public abstract class BaseService<T>(IUnitOfWork unitOfWork, IMapper mapper, ILogger<T> logger) where T : class
{
    public readonly IUnitOfWork UnitOfWork = unitOfWork;
    public readonly IMapper Mapper = mapper;
    public readonly ILogger<T> Logger = logger;

    protected async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> action, string? errorMessage = "An error occurred.")
    {
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "{ErrorMessage}\nMessage: {Message}\nStackTrace: {StackTrace}", errorMessage, ex.Message, ex.StackTrace);
            return default!;
        }
    }
}
