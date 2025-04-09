namespace ControlaEstoque.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
