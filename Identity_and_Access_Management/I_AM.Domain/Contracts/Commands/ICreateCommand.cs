namespace I_AM.Domain.Contracts.Commands;

public interface ICreateCommand<T> where T : class
{
    Task AddAsync(T entity);
}