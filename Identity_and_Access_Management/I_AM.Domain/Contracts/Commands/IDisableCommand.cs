namespace I_AM.Domain.Contracts.Commands;

public interface IDisableCommand<T> where T : class
{
    void Update(T entity);
}