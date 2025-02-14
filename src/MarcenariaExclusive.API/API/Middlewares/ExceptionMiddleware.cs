using MarcenariaExclusive.API.Domain.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DimensoesException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest; // Ou Status422UnprocessableEntity
            await context.Response.WriteAsJsonAsync(new { erro = ex.Message });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new { erro = "Ocorreu um erro inesperado." });
        }
    }
}
