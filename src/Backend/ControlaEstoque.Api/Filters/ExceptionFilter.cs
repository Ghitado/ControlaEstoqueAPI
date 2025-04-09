using ControlaEstoque.Communication.Responses;
using ControlaEstoque.Exception;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ControlaEstoque.Exception.ExceptionsBase;

namespace ControlaEstoque.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ControlaEstoqueException controlaEstoqueException)
            HandleProjectException(controlaEstoqueException, context);
        else
            ThrowUnknowException(context);
    }

    private static void HandleProjectException(ControlaEstoqueException controlaEstoqueException, ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)controlaEstoqueException.GetStatusCode();
        context.Result = new ObjectResult(new ResponseErrorJson(controlaEstoqueException.GetErrorMessages()));
    }

    private static void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessagesException.UNKNOWN_ERROR));
    }
}
