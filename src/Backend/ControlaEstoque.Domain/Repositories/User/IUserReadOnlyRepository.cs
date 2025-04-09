namespace ControlaEstoque.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    public Task<bool> ExistActiveUserWithEmail(string email);
    public Task<bool> ExistActiveUserWithId(Guid userId);
    public Task<Entities.User?> GetByEmail(string email);
    public Task<Entities.User> GetById(Guid userId);
}

