namespace WebApplication4.Exceptions;

public class DomainException : Exception
{
    public string Message { get;  set; }
    public int StatusCode { get;  set; } 
    public DomainException(int statusCode, string message): base(message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}