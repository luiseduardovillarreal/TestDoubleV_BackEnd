using I_AM.Domain.Contracts;
using I_AM.Domain.Entities;
using I_AM.Domain.Repositories;
using I_AM.Domain.Services;
using I_AM.Infrastructure.Persistence.Context;
using I_AM.Infrastructure.Persistence.Contracts;
using I_AM.Infrastructure.Repositories;
using I_AM.Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace I_AM.Infrastructure.Base;

#pragma warning disable CS8625
#pragma warning disable CS8618

public class UnitOfWork(ISurveyDbContext dbContext, IExecuteQuery executeQuery, 
    IConfiguration configuration) : IUnitOfWork
{
    private ISurveyDbContext _dbContext = dbContext;
    private readonly IExecuteQuery _executeQuery = executeQuery;
    private readonly IConfiguration _configuration = configuration;
    private ITokenInquestRepository<TokenInquest> _tokenInquestRepository;
    private IUserRepository<User> _userRepository;
    private IAuthService _authService;

    public ITokenInquestRepository<TokenInquest> TokenInquestRepository => _tokenInquestRepository
        ?? (_tokenInquestRepository = new TokenInquestRepository(_dbContext));

    public IUserRepository<User> UserRepository => _userRepository
        ?? (_userRepository = new UserRepository(_dbContext, _executeQuery, _configuration));

    public IAuthService AuthService => _authService
        ?? (_authService = new AuthService(_configuration));

    public async Task<int> Commit(CancellationToken cancellationToken)
        => await _dbContext.SaveChangesAsync(cancellationToken);

    public void Dispose()
        => Dispose(true);

    private void Dispose(bool disposing)
    {
        if (disposing && _dbContext != null)
        {
            ((SurveyDbContext)_dbContext).DisposeAsync();
            _dbContext = null;
        }
    }
}