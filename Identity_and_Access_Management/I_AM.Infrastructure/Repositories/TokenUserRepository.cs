using I_AM.Domain.Entities;
using I_AM.Domain.Repositories;
using I_AM.Infrastructure.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace I_AM.Infrastructure.Repositories;

#pragma warning disable CS8603

public class TokenUserRepository(IMovementDbContext dbContext) 
    : ITokenUserRepository<TokenUser>
{
    protected IMovementDbContext _dbContext = dbContext;
    protected readonly DbSet<TokenUser> _dbSet = dbContext.Set<TokenUser>();

    public async Task AddAsync(TokenUser entity)
        => await _dbSet.AddAsync(entity);

    public async Task<TokenUser> FindFirstOrDefaultAsync(
        Expression<Func<TokenUser, bool>> predicate) 
            => await _dbSet.FirstOrDefaultAsync(predicate);
}