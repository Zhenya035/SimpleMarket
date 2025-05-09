﻿using System.Text.Json;

namespace SimpleMarket.WebAPI.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = StatusCodes.Status500InternalServerError;
        var message = "An unexpected error occurred.";
        var detailed = string.Empty;

        switch (exception)
        {
            case KeyNotFoundException notFoundEx:
                statusCode = StatusCodes.Status404NotFound;
                message = "Resource not found.";
                detailed = notFoundEx.Message;
                break;

            case InvalidDataException validationEx:
                statusCode = StatusCodes.Status400BadRequest;
                message = "Invalid input data.";
                detailed = validationEx.Message;
                break;
            
            case ArgumentNullException nullException:
                statusCode = StatusCodes.Status400BadRequest;
                message = "Resource cannot be null.";
                detailed = nullException.Message;
                break;

            default:
                detailed = exception.Message;
                break;
        }
        
        context.Response.StatusCode = statusCode;

        var response = new
        {
            StatusCode = statusCode,
            Message = message,
            Detailed = detailed
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

}