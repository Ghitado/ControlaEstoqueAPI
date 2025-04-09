using ControlaEstoque.Domain.Entities;
using ControlaEstoque.Domain.Services.LoggedUser;

namespace ControlaEstoque.Infrastructure.Services.LoggedUser;

public class LoggedUser : ILoggedUser
{
    public Task<User> User()
    {
        throw new NotImplementedException();
    }
}
