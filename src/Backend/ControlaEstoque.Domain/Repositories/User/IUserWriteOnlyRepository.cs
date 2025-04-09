namespace ControlaEstoque.Domain.Repositories.User;

public interface IUserWriteOnlyRepository
{
    public Task Add(Entities.User user);
    public void Update(Entities.User user);
    Task Delete(Guid userId);
}

