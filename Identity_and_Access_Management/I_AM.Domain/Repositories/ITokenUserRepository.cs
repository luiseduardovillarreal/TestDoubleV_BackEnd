using System.Linq.Expressions;

namespace I_AM.Domain.Repositories;

public interface ITokenUserRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
}