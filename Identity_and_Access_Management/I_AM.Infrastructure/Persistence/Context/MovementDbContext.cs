using I_AM.Domain.Entities;
using I_AM.Infrastructure.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace I_AM.Infrastructure.Persistence.Context;

public partial class MovementDbContext : MovementDbContextBase
{
    public DbSet<Module> Modules { get; set; }
    public DbSet<Module_SubModule> Modules_SubModules { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Profile_Module> Profiles_Modules { get; set; }
    public DbSet<Profile_SubModule> Profiles_SubModules { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<SubModule> SubModules { get; set; }
    public DbSet<TokenUser> TokensUsers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<User_Profile> Users_Profiles { get; set; }
    public DbSet<User_Rol> Users_Rols { get; set; }

    public MovementDbContext(DbContextOptions<MovementDbContext> options)
        : base(options)
    {
    }
}