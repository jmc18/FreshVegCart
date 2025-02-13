using AutoMapper;
using FreshVegCart.Api.Interfaces.Persistence;

namespace FreshVegCart.Api.Services;

public abstract class BaseService<T>(IUnitOfWork unitOfWork, IMapper mapper, ILogger<T> logger) where T : class
{
    public IUnitOfWork _unitOfWork = unitOfWork;
    public IMapper _mapper = mapper;
    public ILogger<T> _logger = logger;

    protected async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> action, string errorMessage)
    {
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ErrorMessage}\nMessage: {Message}\nStackTrace: {StackTrace}", errorMessage, ex.Message, ex.StackTrace);
            return default!;
        }
    }
}
