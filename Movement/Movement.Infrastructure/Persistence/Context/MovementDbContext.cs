using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Movement.Domain.Entities;
using Movement.Infrastructure.Persistence.Contracts;
using ConstantsConfigureModules = Movement.Infrastructure.Commons.Constants.Persistence.Context.MovementDbContext.SeedDataModules;
using ConstantsConfigureProfiles = Movement.Infrastructure.Commons.Constants.Persistence.Context.MovementDbContext.SeedDataProfiles;
using ConstantsConfigureSubModules = Movement.Infrastructure.Commons.Constants.Persistence.Context.MovementDbContext.SeedDataSubModules;
using ConstantsConfigureUsers = Movement.Infrastructure.Commons.Constants.Persistence.Context.MovementDbContext.SeedDataUsers;
using ConstantsConfigureModules_SubModules = Movement.Infrastructure.Commons.Constants.Persistence.Context.MovementDbContext.SeedDataModules_SubModules;
using ConstantsConfigureProfiles_Modules = Movement.Infrastructure.Commons.Constants.Persistence.Context.MovementDbContext.SeedDataProfiles_Modules;
using ConstantsConfigureProfiles_SubModules = Movement.Infrastructure.Commons.Constants.Persistence.Context.MovementDbContext.SeedDataProfiles_SubModules;
using ConstantsConfigureUsers_Profiles = Movement.Infrastructure.Commons.Constants.Persistence.Context.MovementDbContext.SeedDataUsers_Profiles;

namespace Movement.Infrastructure.Persistence.Context;

#pragma warning disable CS8601

public partial class MovementDbContext : MovementDbContextBase
{
    private readonly IConfiguration _configuration;
    public DbSet<Debt> Debts { get; set; }
    public DbSet<DebtMovement> DebtsMovements { get; set; }
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

    public MovementDbContext(DbContextOptions<MovementDbContext> options, 
        IConfiguration configuration)
            : base(options)
                => _configuration = configuration;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Module_SubModule>(entity =>
        {
            entity.HasOne(ms => ms.Module)
                .WithMany(m => m.Modules_SubModules)
                .HasForeignKey(ms => ms.IdModule)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ms => ms.SubModule)
                .WithMany(sm => sm.Modules_SubModules)
                .HasForeignKey(ms => ms.IdSubModule)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Debt>(entity =>
        {
            entity.HasOne(ms => ms.UserDebtor)
                .WithMany(m => m.DebtsDebtor)
                .HasForeignKey(ms => ms.IdUserDebtor)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ms => ms.UserCreditor)
                .WithMany(sm => sm.DebtsCreditor)
                .HasForeignKey(ms => ms.IdUserCreditor)
                .OnDelete(DeleteBehavior.Restrict);
        });

        ConfigureModules(modelBuilder);
        ConfigureProfiles(modelBuilder);
        ConfigureSubModules(modelBuilder);
        ConfigureUsers(modelBuilder, _configuration);
        ConfigureModules_SubModules(modelBuilder);
        ConfigureProfiles_Modules(modelBuilder);
        ConfigureProfiles_SubModules(modelBuilder);
        ConfigureUser_Profile(modelBuilder);
    }

    private static void ConfigureModules(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Module>().HasData([
            new()
            {
                Id = Guid.Parse(ConstantsConfigureModules.GUID_DASHBOARD),
                Name = ConstantsConfigureModules.DASHBOARD,
                Description = ConstantsConfigureModules.DESCRIPTION_DASHBOARD,
                Icon = ConstantsConfigureModules.ICON_DASHBOARD,
                CreateAt = new DateTime(2025, 09, 04, 12, 00, 00, DateTimeKind.Utc),
                UpdateAt = null,
                IsActive = true
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureModules.GUID_CONFIGURATION),
                Name = ConstantsConfigureModules.CONFIGURATION,
                Description = ConstantsConfigureModules.DESCRIPTION_CONFIGURATION,
                Icon = ConstantsConfigureModules.ICON_CONFIGURATION,
                CreateAt = new DateTime(2025, 09, 05, 12, 00, 00, DateTimeKind.Utc),
                UpdateAt = null,
                IsActive = true
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureModules.GUID_DEBT),
                Name = ConstantsConfigureModules.DEBT,
                Description = ConstantsConfigureModules.DESCRIPTION_DEBT,
                Icon = ConstantsConfigureModules.ICON_DEBT,
                CreateAt = new DateTime(2025, 09, 06, 12, 00, 00, DateTimeKind.Utc),
                UpdateAt = null,
                IsActive = true
            }
        ]);

    private static void ConfigureProfiles(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Profile>().HasData([
            new()
            {
                Id = Guid.Parse(ConstantsConfigureProfiles.GUID_PROFILE_SUP_ADM),
                Code = 1,
                Name = ConstantsConfigureProfiles.PROFILE_SUP_ADM,
                Description = ConstantsConfigureProfiles.DESCRIPTION_PROFILE_SUP_ADM,
                CreateAt = new DateTime(2025, 09, 04, 12, 00, 00, DateTimeKind.Utc),
                UpdateAt = null,
                IsActive = true
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureProfiles.GUID_PROFILE_USER),
                Code = 2,
                Name = ConstantsConfigureProfiles.PROFILE_USER,
                Description = ConstantsConfigureProfiles.DESCRIPTION_PROFILE_USER,
                CreateAt = new DateTime(2025, 09, 05, 12, 00, 00, DateTimeKind.Utc),
                UpdateAt = null,
                IsActive = true
            }
        ]);

    private static void ConfigureSubModules(ModelBuilder modelBuilder)
        => modelBuilder.Entity<SubModule>().HasData([
            new()
            {
                Id = Guid.Parse(ConstantsConfigureSubModules.GUID_LIST_USERS),
                Name = ConstantsConfigureSubModules.LIST_USERS,
                Description = ConstantsConfigureSubModules.DESCRIPTION_LIST_USERS,
                RouterLink = ConstantsConfigureSubModules.ROUTER_LINK_LIST_USERS,
                CreateAt = new DateTime(2025, 09, 06, 12, 00, 00, DateTimeKind.Utc),
                UpdateAt = null,
                IsActive = true
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureSubModules.GUID_LIST_DEBTS),
                Name = ConstantsConfigureSubModules.LIST_DEBTS,
                Description = ConstantsConfigureSubModules.DESCRIPTION_LIST_DEBTS,
                RouterLink = ConstantsConfigureSubModules.ROUTER_LINK_LIST_DEBTS,
                CreateAt = new DateTime(2025, 09, 07, 12, 00, 00, DateTimeKind.Utc),
                UpdateAt = null,
                IsActive = true
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureSubModules.GUID_LIST_PAYS),
                Name = ConstantsConfigureSubModules.LIST_PAYS,
                Description = ConstantsConfigureSubModules.DESCRIPTION_LIST_PAYS,
                RouterLink = ConstantsConfigureSubModules.ROUTER_LINK_LIST_PAYS,
                CreateAt = new DateTime(2025, 09, 08, 12, 00, 00, DateTimeKind.Utc),
                UpdateAt = null,
                IsActive = true
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureSubModules.GUID_MANAGE_DEBTS),
                Name = ConstantsConfigureSubModules.MANAGE_DEBTS,
                Description = ConstantsConfigureSubModules.DESCRIPTION_MANAGE_DEBTS,
                RouterLink = ConstantsConfigureSubModules.ROUTER_LINK_MANAGE_DEBTS,
                CreateAt = new DateTime(2025, 09, 06, 12, 00, 00, DateTimeKind.Utc),
                UpdateAt = null,
                IsActive = true
            }         
        ]);

    private static void ConfigureUsers(ModelBuilder modelBuilder, IConfiguration configuration)
        => modelBuilder.Entity<User>().HasData([
            new()
            {
                Id = Guid.Parse(ConstantsConfigureUsers.GUID_USER_SUP_ADM),
                Names = configuration[ConstantsConfigureUsers.NAMES_USER_SUP_ADM],
                LastNames = configuration[ConstantsConfigureUsers.LASTNAMES_USER_SUP_ADM],
                Email = configuration[ConstantsConfigureUsers.EMAIL_USER_SUP_ADM],
                Password = configuration[ConstantsConfigureUsers.PASSWORD_USER_SUP_ADM],
                CreateAt = new DateTime(2025, 06, 04, 12, 00, 00, DateTimeKind.Utc),
                UpdateAt = null,
                IsActive = true
            }
        ]);

    private static void ConfigureModules_SubModules(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Module_SubModule>().HasData([
            new()
            {
                Id = Guid.Parse(ConstantsConfigureModules_SubModules.GUID_CONFIGURATION_LIST_USERS),
                IdModule = Guid.Parse(ConstantsConfigureModules.GUID_CONFIGURATION),
                IdSubModule = Guid.Parse(ConstantsConfigureSubModules.GUID_LIST_USERS),
                CreateAt = new DateTime(2025, 09, 05, 12, 01, 00, DateTimeKind.Utc)
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureModules_SubModules.GUID_CONFIGURATION_LIST_DEBTS),
                IdModule = Guid.Parse(ConstantsConfigureModules.GUID_CONFIGURATION),
                IdSubModule = Guid.Parse(ConstantsConfigureSubModules.GUID_LIST_DEBTS),
                CreateAt = new DateTime(2025, 09, 05, 12, 02, 00, DateTimeKind.Utc)
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureModules_SubModules.GUID_CONFIGURATION_LIST_PAYS),
                IdModule = Guid.Parse(ConstantsConfigureModules.GUID_CONFIGURATION),
                IdSubModule = Guid.Parse(ConstantsConfigureSubModules.GUID_LIST_PAYS),
                CreateAt = new DateTime(2025, 09, 05, 12, 03, 00, DateTimeKind.Utc)
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureModules_SubModules.GUID_DEBT_MANAGE_DEBTS),
                IdModule = Guid.Parse(ConstantsConfigureModules.GUID_DEBT),
                IdSubModule = Guid.Parse(ConstantsConfigureSubModules.GUID_MANAGE_DEBTS),
                CreateAt = new DateTime(2025, 09, 06, 12, 00, 00, DateTimeKind.Utc)
            }
        ]);

    private static void ConfigureProfiles_Modules(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Profile_Module>().HasData([
            new()
            {
                Id = Guid.Parse(ConstantsConfigureProfiles_Modules.GUID_PROFILE_SUP_ADM_DASHBOARD),
                IdProfile = Guid.Parse(ConstantsConfigureProfiles.GUID_PROFILE_SUP_ADM),
                IdModule = Guid.Parse(ConstantsConfigureModules.GUID_DASHBOARD),
                CreateAt = new DateTime(2025, 09, 04, 12, 00, 00, DateTimeKind.Utc)
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureProfiles_Modules.GUID_PROFILE_SUP_ADM_CONFIGURATION),
                IdProfile = Guid.Parse(ConstantsConfigureProfiles.GUID_PROFILE_SUP_ADM),
                IdModule = Guid.Parse(ConstantsConfigureModules.GUID_CONFIGURATION),
                CreateAt = new DateTime(2025, 09, 05, 12, 00, 00, DateTimeKind.Utc)
            }
        ]);

    private static void ConfigureProfiles_SubModules(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Profile_SubModule>().HasData([
            new()
            {
                Id = Guid.Parse(ConstantsConfigureProfiles_SubModules.GUID_PROFILE_SUP_ADM_LIST_USERS),
                IdProfile = Guid.Parse(ConstantsConfigureProfiles.GUID_PROFILE_SUP_ADM),
                IdSubModule = Guid.Parse(ConstantsConfigureSubModules.GUID_LIST_USERS),
                CreateAt = new DateTime(2025, 06, 06, 12, 01, 00, DateTimeKind.Utc)
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureProfiles_SubModules.GUID_PROFILE_SUP_ADM_LIST_DEBTS),
                IdProfile = Guid.Parse(ConstantsConfigureProfiles.GUID_PROFILE_SUP_ADM),
                IdSubModule = Guid.Parse(ConstantsConfigureSubModules.GUID_LIST_DEBTS),
                CreateAt = new DateTime(2025, 06, 05, 12, 00, 00, DateTimeKind.Utc)
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureProfiles_SubModules.GUID_PROFILE_SUP_ADM_LIST_PAYS),
                IdProfile = Guid.Parse(ConstantsConfigureProfiles.GUID_PROFILE_SUP_ADM),
                IdSubModule = Guid.Parse(ConstantsConfigureSubModules.GUID_LIST_PAYS),
                CreateAt = new DateTime(2025, 06, 05, 12, 02, 00, DateTimeKind.Utc)
            },
            new()
            {
                Id = Guid.Parse(ConstantsConfigureProfiles_SubModules.GUID_PROFILE_USER_MANAGE_DEBTS),
                IdProfile = Guid.Parse(ConstantsConfigureProfiles.GUID_PROFILE_SUP_ADM),
                IdSubModule = Guid.Parse(ConstantsConfigureSubModules.GUID_MANAGE_DEBTS),
                CreateAt = new DateTime(2025, 06, 06, 12, 00, 00, DateTimeKind.Utc)
            }
        ]);

    private static void ConfigureUser_Profile(ModelBuilder modelBuilder)
        => modelBuilder.Entity<User_Profile>().HasData([
            new()
            {
                Id = Guid.Parse(ConstantsConfigureUsers_Profiles.GUID_USER_SUP_ADM_PROFILE_SUP_ADM),
                IdUser = Guid.Parse(ConstantsConfigureUsers.GUID_USER_SUP_ADM),
                IdProfile = Guid.Parse(ConstantsConfigureProfiles.GUID_PROFILE_SUP_ADM),
                CreateAt = new DateTime(2025, 06, 04, 12, 00, 00, DateTimeKind.Utc)
            }
        ]);
}