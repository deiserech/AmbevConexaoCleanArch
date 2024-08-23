using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AmbevConexao.API.Filters;

public class CustomExceptionsFilter : IExceptionFilter
{
    //acontece qdo estoura exceção no código
    public void OnException(ExceptionContext context)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var message = "ocorreu erro";

        if (context.Exception is NotFoundException)
        {
            statusCode = HttpStatusCode.NotFound;
            message = "recurso naõ encontrado";
        }

        context.Result = new ObjectResult(
            new
            {
                StatusCode = statusCode,
                Message = message
            })
        { StatusCode = (int)statusCode };

        context.ExceptionHandled = true;
    }
}
