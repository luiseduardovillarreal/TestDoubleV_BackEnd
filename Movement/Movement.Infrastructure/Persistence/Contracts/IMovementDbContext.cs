using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Movement.Infrastructure.Persistence.Contracts;

public interface IMovementDbContext
{
    void DetachEntity(object entity);
    ValueTask DisposeAsync();
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);    
    DatabaseFacade Database { get; }
}