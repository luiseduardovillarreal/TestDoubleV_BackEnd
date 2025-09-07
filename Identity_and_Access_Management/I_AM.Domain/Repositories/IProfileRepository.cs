using System.Linq.Expressions;

namespace I_AM.Domain.Repositories;

public interface IProfileRepository<T> where T : class
{
    Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
}