namespace I_AM.Domain.Contracts.Commands;

public interface IUpdateCommand<T> where T : class
{
    void Update(T entity);
}