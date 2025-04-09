namespace ControlaEstoque.Domain.Repositories.Sale;

public interface ISaleReadOnlyRepository
{
    Task<Entities.Sale?> GetById(Guid id);
    Task<IEnumerable<Entities.Sale>> Get();
}

