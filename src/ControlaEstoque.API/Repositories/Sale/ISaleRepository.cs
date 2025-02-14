namespace ControlaEstoque.API.Repositories.Sale;

public interface ISaleRepository
{
    Task<Models.Sale?> GetById(Guid id);
    Task<IEnumerable<Models.Sale>> GetAll();
    Task Add(Models.Sale sale);
    Task Update(Models.Sale sale);
    Task Delete(Models.Sale sale);
}
