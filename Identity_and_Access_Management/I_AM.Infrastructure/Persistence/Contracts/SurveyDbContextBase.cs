using Microsoft.EntityFrameworkCore;

namespace I_AM.Infrastructure.Persistence.Contracts;

public partial class SurveyDbContextBase : DbContext, ISurveyDbContext
{
    public SurveyDbContextBase(DbContextOptions options)
        : base(options)
    {
    }
}