using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AmbevConexao.API.Filters;

public class CustomAuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context) {
        Console.WriteLine("Filter");

        var headers = context.HttpContext.Request.Headers;

        if (!headers.ContainsKey("Ambev"))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
