using I_AM.Domain.Entities;
using I_AM.Domain.Repositories;
using I_AM.Infrastructure.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace I_AM.Infrastructure.Repositories;

#pragma warning disable CS8603

public class TokenInquestRepository(ISurveyDbContext dbContext) 
    : ITokenInquestRepository<TokenInquest>
{
    protected ISurveyDbContext _dbContext = dbContext;
    protected readonly DbSet<TokenInquest> _dbSet = dbContext.Set<TokenInquest>();

    public async Task AddAsync(TokenInquest entity)
        => await _dbSet.AddAsync(entity);

    public async Task<TokenInquest> FindFirstOrDefaultAsync(
        Expression<Func<TokenInquest, bool>> predicate) 
            => await _dbSet.FirstOrDefaultAsync(predicate);
}