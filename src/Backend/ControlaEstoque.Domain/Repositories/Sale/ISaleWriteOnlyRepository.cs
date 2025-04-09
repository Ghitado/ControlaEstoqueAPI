namespace ControlaEstoque.Domain.Repositories.Sale;

public interface ISaleWriteOnlyRepository
{
    Task Add(Entities.Sale sale);
    void Update(Entities.Sale sale);
    Task Delete(Guid saleId);
}

