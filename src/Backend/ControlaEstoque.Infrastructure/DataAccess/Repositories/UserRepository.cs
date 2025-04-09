using ControlaEstoque.Domain.Entities;
using ControlaEstoque.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly ControlaEstoqueDbContext _dbContext;

    public UserRepository(ControlaEstoqueDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(User user) => await _dbContext.Users.AddAsync(user);

    public async Task<bool> ExistActiveUserWithEmail(string email) => await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);

    public async Task<bool> ExistActiveUserWithId(Guid id) => await _dbContext.Users.AnyAsync(user => user.Id.Equals(id) && user.Active);

    public async Task<User> GetById(Guid id)
    {
        return await _dbContext
            .Users
            .FirstAsync(user => user.Id == id);
    }

    public void Update(User user) => _dbContext.Users.Update(user);

    public async Task Delete(Guid userIdentifier)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userIdentifier);
        if (user is null)
            return;

        //var recipes = _dbContext.Recipes.Where(recipe => recipe.UserId == user.Id);

        //_dbContext.Recipes.RemoveRange(recipes);

        _dbContext.Users.Remove(user);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _dbContext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Active && user.Email.Equals(email));
    }
}
