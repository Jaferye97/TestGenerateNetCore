namespace Application.Commons;

public class Result<T>
{
    public ResultType Type { get; }
    public T? Data { get; }
    public string? Message { get; }

    private Result(ResultType type, T? data = default, string? message = null)
    {
        Type = type;
        Data = data;
        Message = message;
    }

    public static Result<T> Success(T data, string? message = null) =>
        new(ResultType.Success, data, message);

    public static Result<T> NotFound(string message) =>
        new(ResultType.NotFound, default, message);

    public static Result<T> ValidationError(string message) =>
        new(ResultType.ValidationError, default, message);

    public static Result<T> BusinessError(string message) =>
        new(ResultType.BusinessError, default, message);

    public static Result<T> SystemError(string message) =>
        new(ResultType.SystemError, default, message);
}
