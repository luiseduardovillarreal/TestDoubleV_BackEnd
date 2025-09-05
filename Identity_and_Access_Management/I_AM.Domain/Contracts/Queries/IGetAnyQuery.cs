using System.Linq.Expressions;

public interface IGetAnyQuery<T> where T : class
{
    Task<T> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
}