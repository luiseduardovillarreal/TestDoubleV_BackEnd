using System.Linq.Expressions;

namespace I_AM.Domain.Repositories;

public interface IUserRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task<IEnumerable<T>> FindAllAsync();
    Task<T> FindAnyByEmailAsync(string email);
    Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    void Update(T entity);
}