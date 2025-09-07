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

public class UnitOfWork(IMovementDbContext dbContext, IConfiguration configuration) 
    : IUnitOfWork
{
    private IMovementDbContext _dbContext = dbContext;
    private readonly IConfiguration _configuration = configuration;
    private IAuthService _authService;
    private IProfileRepository<Profile> _profileRepository;
    private ITokenUserRepository<TokenUser> _tokenUserRepository;
    private IUserRepository<User> _userRepository;
    
    public IAuthService AuthService => _authService
        ?? (_authService = new AuthService(_configuration));

    public IProfileRepository<Profile> ProfileRepository => _profileRepository
        ?? (_profileRepository = new ProfileRepository(_dbContext));

    public ITokenUserRepository<TokenUser> TokenUserRepository => _tokenUserRepository
        ?? (_tokenUserRepository = new TokenUserRepository(_dbContext));

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