using I_AM.Domain.Entities;
using I_AM.Domain.Repositories;
using I_AM.Infrastructure.Commons;
using I_AM.Infrastructure.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq.Expressions;

namespace I_AM.Infrastructure.Repositories;

#pragma warning disable CS8603
#pragma warning disable CS8604

public class UserRepository(IMovementDbContext dbContext, IExecuteQuery executeQuery,
    IConfiguration configuration) : IUserRepository<User>
{
    protected IMovementDbContext _dbContext = dbContext;
    protected readonly DbSet<User> _dbSet = dbContext.Set<User>();
    private readonly IExecuteQuery _executeQuery = executeQuery;
    private readonly IConfiguration _configuration = configuration;

    public async Task<User> FindFirstOrDefaultAsync(Expression<Func<User, bool>> predicate)
        => await _dbSet.FirstOrDefaultAsync(predicate);

    public async Task<string> GetUserAccessDetails(Guid idUser)
        => await _executeQuery.GetQuery(
            _configuration[Constants.Repositories.UserRepository.SP_GET_USER_ACCESS_DETAILS],
                new()
                {
                    new()
                    {
                        DbType = DbType.Guid,
                        ParameterName = Constants.Repositories.UserRepository.ID_USER,
                        Direction = ParameterDirection.Input,
                        Value = idUser
                    }
                });
}