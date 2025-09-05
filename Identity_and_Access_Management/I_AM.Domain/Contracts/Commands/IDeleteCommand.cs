namespace I_AM.Domain.Contracts.Commands;

public interface IDeleteCommand<T> where T : class
{
    void Delete(T entity);
}