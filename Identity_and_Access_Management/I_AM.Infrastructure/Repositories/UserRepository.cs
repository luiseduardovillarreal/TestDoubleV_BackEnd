using I_AM.Domain.Entities;
using I_AM.Domain.Repositories;
using I_AM.Infrastructure.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace I_AM.Infrastructure.Repositories;

#pragma warning disable CS8603

public class UserRepository(IMovementDbContext dbContext) 
    : IUserRepository<User>
{
    protected IMovementDbContext _dbContext = dbContext;
    protected readonly DbSet<User> _dbSet = dbContext.Set<User>();

    public async Task AddAsync(User entity)
        => await _dbSet.AddAsync(entity);

    public async Task<IEnumerable<User>> FindAllAsync()
        => await _dbSet.ToListAsync();

    public async Task<User> FindAnyByEmailAsync(string email)
        => await _dbSet
            .Include(u => u.Users_Profiles)
                .ThenInclude(up => up.Profile)
                    .ThenInclude(p => p.Profiles_Modules)
                        .ThenInclude(pm => pm.Module)
            .Include(u => u.Users_Profiles)
                .ThenInclude(up => up.Profile)
                    .ThenInclude(p => p.Profiles_SubModules)
                        .ThenInclude(psm => psm.SubModule)
            .Include(u => u.Users_Rols)
            .AsSplitQuery()
            .FirstOrDefaultAsync(u => u.Email.Equals(email));

    public async Task<User> FindFirstOrDefaultAsync(Expression<Func<User, bool>> predicate)
        => await _dbSet.FirstOrDefaultAsync(predicate);

    public void Update(User entity)
        => _dbSet.Update(entity);
}