using System.Linq.Expressions;

namespace I_AM.Domain.Repositories;

public interface IUserRepository<T> where T : class
{
    Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<string> GetUserAccessDetails(Guid idUser);
}