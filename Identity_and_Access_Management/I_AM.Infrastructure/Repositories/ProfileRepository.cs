using I_AM.Domain.Entities;
using I_AM.Domain.Repositories;
using I_AM.Infrastructure.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace I_AM.Infrastructure.Repositories;

#pragma warning disable CS8603

public class ProfileRepository(IMovementDbContext dbContext) 
    : IProfileRepository<Profile>
{
    protected IMovementDbContext _dbContext = dbContext;
    protected readonly DbSet<Profile> _dbSet = dbContext.Set<Profile>();

    public async Task<Profile> FindFirstOrDefaultAsync(Expression<Func<Profile, 
        bool>> predicate)
            => await _dbSet.FirstOrDefaultAsync(predicate);
}