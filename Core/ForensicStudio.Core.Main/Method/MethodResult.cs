using System;

namespace ForensicStudio.Core.Main.Method;

public class MethodResult<T> : MethodResult
{
    public T Result { get; set; }

    public MethodResult(T result)
    {
        Result = result;
        IsSuccess = true;
    }

    public MethodResult(Exception exception) : base(exception)
    {
    }

    public MethodResult(string message) : base(message)
    {
    }
}

public class MethodResult
{
    public bool IsSuccess { get; set; }
    public Exception? Exception { get; set; }
    public string? Message { get; set; }

    public MethodResult()
    {
        IsSuccess = true;
        Exception = null;
        Message = null;
    }

    public MethodResult(Exception exception)
    {
        Exception = exception;
        IsSuccess = false;
    }

    public MethodResult(string message)
    {
        Message = message;
        IsSuccess = false;
    }
}