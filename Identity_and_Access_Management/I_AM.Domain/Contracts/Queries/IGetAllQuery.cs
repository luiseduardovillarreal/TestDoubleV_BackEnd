using System.Linq.Expressions;

public interface IGetAllQuery<T> where T : class
{
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
}