using Microsoft.EntityFrameworkCore;
using Movement.Domain.Entities;
using Movement.Domain.Repositories;
using Movement.Infrastructure.Persistence.Contracts;
using System.Data;
using System.Linq.Expressions;

namespace Movement.Infrastructure.Repositories;

#pragma warning disable CS8603
#pragma warning disable CS8604

public class DebtRepository(IMovementDbContext dbContext) : IDebtRepository<Debt>
{
    protected IMovementDbContext _dbContext = dbContext;
    protected readonly DbSet<Debt> _dbSet = dbContext.Set<Debt>();

    public async Task AddAsync(Debt entity)
        => await _dbSet.AddAsync(entity);

    public void Delete(Debt entity)
        => _dbSet.Update(entity);

    public async Task<IEnumerable<Debt>> FindAllAsync()
        => await _dbSet.ToListAsync();

    public async Task<Debt> FindFirstOrDefaultAsync(Expression<Func<Debt, bool>> predicate)
        => await _dbSet.FirstOrDefaultAsync(predicate);

    public void Update(Debt entity)
        => _dbSet.Update(entity);

    public IQueryable<Debt> Where(Expression<Func<Debt, bool>> predicate)
        => _dbSet.Where(predicate);
}