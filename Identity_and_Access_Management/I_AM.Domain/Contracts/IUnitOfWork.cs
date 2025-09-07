using I_AM.Domain.Entities;
using I_AM.Domain.Repositories;
using I_AM.Domain.Services;

namespace I_AM.Domain.Contracts;

public interface IUnitOfWork : IDisposable
{
    IAuthService AuthService { get; }
    IProfileRepository<Profile> ProfileRepository { get; }
    ITokenUserRepository<TokenUser> TokenUserRepository { get; }
    IUserRepository<User> UserRepository { get; }    
    Task<int> Commit(CancellationToken cancellationToken);
    new void Dispose();
}