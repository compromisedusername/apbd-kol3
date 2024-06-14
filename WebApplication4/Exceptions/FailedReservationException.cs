namespace WebApplication4.Exceptions;

public class FailedReservationException : Exception
{
    public string Message { get;  set; }
    public int StatusCode { get;  set; } 
    public int ClientId { get; set; }
    public FailedReservationException(int statusCode, string message, int clientId): base(message)
    {
        StatusCode = statusCode;
        Message = message;
        ClientId = clientId;
    }
}