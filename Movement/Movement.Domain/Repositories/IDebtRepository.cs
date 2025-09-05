using System.Linq.Expressions;

namespace Movement.Domain.Repositories;

public interface IDebtRepository<T> where T : class
{
    Task AddAsync(T entity);
    void Delete(T entity);
    Task<IEnumerable<T>> FindAllAsync();
    Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    void Update(T entity);
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
}