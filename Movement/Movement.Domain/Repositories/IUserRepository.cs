using System.Linq.Expressions;

namespace Movement.Domain.Repositories;

public interface IUserRepository<T> where T : class
{
    Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
}