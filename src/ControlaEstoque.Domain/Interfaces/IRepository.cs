namespace ControlaEstoque.Domain.Interfaces;
public interface IRepository<T> where T : class
{
    Task<T?> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task Add(T entity);
    Task Update(Guid id, T entity);
    Task Delete(Guid id);
}

