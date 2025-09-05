using Microsoft.EntityFrameworkCore;

namespace I_AM.Infrastructure.Persistence.Contracts;

public partial class MovementDbContextBase : DbContext, IMovementDbContext
{
    public MovementDbContextBase(DbContextOptions options)
        : base(options)
    {
    }
}