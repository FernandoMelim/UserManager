using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Infrastructure.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var result = "";

            switch (error)
            {
                case ObjectNotFoundException:
                    // couldn't find the resource
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new { message = "Recurso não foi encontrado" });
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result = JsonSerializer.Serialize(new { message = "Ocorreu um erro no servidor" });
                    break;
            }

            //var result = JsonSerializer.Serialize(new { message = error?.Message });

            await response.WriteAsync(result);
        }
    }
}

