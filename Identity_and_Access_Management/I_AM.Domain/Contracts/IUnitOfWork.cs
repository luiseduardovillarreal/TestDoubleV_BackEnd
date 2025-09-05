using I_AM.Domain.Entities;
using I_AM.Domain.Repositories;
using I_AM.Domain.Services;

namespace I_AM.Domain.Contracts;

public interface IUnitOfWork : IDisposable
{
    ITokenInquestRepository<TokenInquest> TokenInquestRepository { get; }
    IUserRepository<User> UserRepository { get; }
    IAuthService AuthService { get; }
    Task<int> Commit(CancellationToken cancellationToken);
    new void Dispose();
}