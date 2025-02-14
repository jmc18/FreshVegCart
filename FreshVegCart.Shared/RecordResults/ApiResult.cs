namespace FreshVegCart.Shared.RecordResults;

public record ApiResult(bool IsSuccess, string? ErrorMessage)
{
    public static ApiResult Success() => new(true, null);
    public static ApiResult Failure(string errorMessage) => new(false, errorMessage);
}

public record ApiResult<TData>(bool IsSuccess, TData Data, string? ErrorMessage)
{
    public static ApiResult<TData> Success(TData data) => new(true, data, null);
    public static ApiResult<TData> Failure(string errorMessage) => new(false, default!, errorMessage);
}