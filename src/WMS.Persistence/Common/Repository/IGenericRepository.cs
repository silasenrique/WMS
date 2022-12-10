using System.Linq.Expressions;

namespace WMS.Persistence.Common.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    void Create(TEntity objectToCreate);
    void Update(TEntity objectToChange);
    void Delete(TEntity objectToDelete);
    IEnumerable<TEntity>? Get(Expression<Func<TEntity, bool>> filter);
}