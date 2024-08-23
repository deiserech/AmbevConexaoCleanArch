namespace AmbevConexao.API.Mid;

public class HeadersMiddleware
{
    private readonly RequestDelegate _next;

    public HeadersMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Antes Middleware");

        var headers = context.Request.Headers;
        
        //if(!headers.ContainsKey("Ambev"))
        //    return; //Curto circuíto

        await _next(context);

        Console.WriteLine("Depois Middleware");
    }
}
