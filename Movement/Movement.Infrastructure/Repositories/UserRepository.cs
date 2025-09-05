using Microsoft.EntityFrameworkCore;
using Movement.Domain.Entities;
using Movement.Domain.Repositories;
using Movement.Infrastructure.Persistence.Contracts;
using System.Linq.Expressions;

namespace Movement.Infrastructure.Repositories;

#pragma warning disable

public class UserRepository(IMovementDbContext dbContext) : IUserRepository<User>
{
    protected IMovementDbContext _dbContext = dbContext;
    protected readonly DbSet<User> _dbSet = dbContext.Set<User>();

    public async Task<User> FindFirstOrDefaultAsync(Expression<Func<User, bool>> predicate)
        => await _dbSet.FirstOrDefaultAsync(predicate);
}