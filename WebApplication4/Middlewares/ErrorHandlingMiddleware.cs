using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Exceptions;

namespace WebApplication4.Middlewares;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ApplicationContext dbContext,
    Logger<ExceptionHandlingMiddleware> logger)
{
    private readonly ApplicationContext _dbContext = dbContext;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (FailedReservationException ex)
        {
            await HandleFailedReservationExceptionAsync(context, ex);
        }
        catch (DomainException ex)
        {
            await HandleDomainException(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }


    private static Task HandleDomainException(HttpContext context, DomainException ex)
    {
        
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex.StatusCode;
        
        
        

        var response = new
        {
            message = ex.Message,
            statusCode = ex.StatusCode
        };

        return  context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static Task HandleFailedReservationExceptionAsync(HttpContext context, FailedReservationException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex.StatusCode;

        var response = new
        {
            message = ex.Message,
            statusCode = ex.StatusCode
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
    
    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            errorCode = 500,
            message = "An unexpected error occurred.",
            statusCode = context.Response.StatusCode
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
   
    
}