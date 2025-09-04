using Movement.Domain.Entities;
using Movement.Domain.Repositories;

namespace Movement.Domain.Contracts;

public interface IUnitOfWork : IDisposable
{
    IDebtRepository<Debt> DebtRepository { get; }
    Task<int> Commit(CancellationToken cancellationToken);
    new void Dispose();
}