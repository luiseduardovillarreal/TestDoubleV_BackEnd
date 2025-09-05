using Movement.Domain.Contracts;
using Movement.Domain.Entities;
using Movement.Domain.Repositories;
using Movement.Infrastructure.Persistence.Context;
using Movement.Infrastructure.Persistence.Contracts;
using Movement.Infrastructure.Repositories;

namespace Movement.Infrastructure.Base;

#pragma warning disable CS8625
#pragma warning disable CS8618

public class UnitOfWork(IMovementDbContext dbContext) : IUnitOfWork
{
    private IMovementDbContext _dbContext = dbContext;
    private IDebtRepository<Debt> _debtRepository;
    private IUserRepository<User> _userRepository;

    public IDebtRepository<Debt> DebtRepository => _debtRepository
        ?? (_debtRepository = new DebtRepository(_dbContext));

    public IUserRepository<User> UserRepository => _userRepository
        ?? (_userRepository = new UserRepository(_dbContext));

    public async Task<int> Commit(CancellationToken cancellationToken)
        => await _dbContext.SaveChangesAsync(cancellationToken);

    public void Dispose()
        => Dispose(true);

    private void Dispose(bool disposing)
    {
        if (disposing && _dbContext != null)
        {
            ((MovementDbContext)_dbContext).DisposeAsync();
            _dbContext = null;
        }
    }
}