using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WMS.Persistence.Configuration;

namespace WMS.Persistence.Common.Repository;

public abstract class GenericRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationContext _context;
    private readonly DbSet<TEntity> _dbSet;

    protected GenericRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public void Create(TEntity objectToCreate)
    {
        _context.Add(objectToCreate);
    }

    public void Update(TEntity objectToChange)
    {
        _dbSet.Update(objectToChange);
    }

    public void Delete(TEntity objectToDelete)
    {
        _dbSet.Remove(objectToDelete);
    }

    public IEnumerable<TEntity>? Get(Expression<Func<TEntity, bool>> filter)
    {
        return _dbSet.Where(filter).ToList();
    }
}