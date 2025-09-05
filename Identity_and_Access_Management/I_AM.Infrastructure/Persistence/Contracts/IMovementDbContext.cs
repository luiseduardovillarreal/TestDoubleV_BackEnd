using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace I_AM.Infrastructure.Persistence.Contracts;

public interface IMovementDbContext
{
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    ValueTask DisposeAsync();
    DatabaseFacade Database { get; }
}