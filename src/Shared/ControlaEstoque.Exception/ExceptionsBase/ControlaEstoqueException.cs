using System.Net;

namespace ControlaEstoque.Exception.ExceptionsBase;

public abstract class ControlaEstoqueException : SystemException
{
    protected ControlaEstoqueException(string message) : base(message) { }

    public abstract IList<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();
}