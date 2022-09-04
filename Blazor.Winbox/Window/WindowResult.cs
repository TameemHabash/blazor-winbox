namespace Blazor.Winbox;

public class WindowResult
{
    public object Data { get; }
    public Type DataType { get; }
    public bool Cancelled { get; }

    protected internal WindowResult(object data, Type resultType, bool cancelled)
    {
        Data = data;
        DataType = resultType;
        Cancelled = cancelled;
    }

    public static WindowResult Ok<T>(T result) => Ok(result, default);

    public static WindowResult Ok<T>(T result, Type windowType) => new(result, windowType, false);

    public static WindowResult Cancel() => new(default, typeof(object), true);
}
