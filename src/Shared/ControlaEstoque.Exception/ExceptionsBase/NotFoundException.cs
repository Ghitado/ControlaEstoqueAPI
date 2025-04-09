using System.Net;

namespace ControlaEstoque.Exception.ExceptionsBase;

public class NotFoundException : ControlaEstoqueException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override IList<string> GetErrorMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
}
