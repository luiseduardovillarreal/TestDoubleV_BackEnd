using System.Linq.Expressions;

namespace Movement.Domain.Repositories;

public interface IDebtRepository<T> where T : class
{
    Task AddAsync(T entity);
    void Delete(T entity);
    Task<T?> FindAnyByIdAsync(Guid idDebt);
    Task<IEnumerable<T>> FindAllAsync();
    Task<IEnumerable<T>> FindAllByUserDebtorAsync(Guid idUserDebtor);
    Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    void Update(T entity);
}