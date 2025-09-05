using Microsoft.EntityFrameworkCore;

namespace Movement.Infrastructure.Persistence.Contracts;

public partial class MovementDbContextBase : DbContext, IMovementDbContext
{
    public MovementDbContextBase(DbContextOptions options)
        : base(options)
    {
    }

    public void DetachEntity(object entity)
        => Entry(entity).State = EntityState.Detached;
}