using ControlaEstoque.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlaEstoque.Infrastructure.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _dbContext;
    protected readonly IUnitOfWork _unitOfWork;

    public Repository(DbContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = dbContext;
        _unitOfWork = unitOfWork;
    }

    public async Task<T?> GetById(Guid id) => await _dbContext.Set<T>().FindAsync(id);

    public async Task<IEnumerable<T>> GetAll() => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

    public async Task Add(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _unitOfWork.Commit();
    }

    public async Task Update(Guid id, T entity)
    {
        var entityExist = await _dbContext.Set<T>().FindAsync(id);

        if (entity is null)
            return;

        _dbContext.Set<T>().Update(entity);
        await _unitOfWork.Commit();
    }

    public async Task Delete(Guid id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);

        if (entity is null)
            return;

        _dbContext.Set<T>().Remove(entity);
        await _unitOfWork.Commit();
    }
}

