using ControlaEstoque.Domain.Entities;

namespace ControlaEstoque.Domain.Services.LoggedUser;

public interface ILoggedUser
{
    Task<User> User();
}
