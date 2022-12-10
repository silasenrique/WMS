using Microsoft.EntityFrameworkCore;
using WMS.Domain.DistributionCenter;
using WMS.Persistence.DistributionCenterPersistence;

namespace WMS.Persistence.Configuration;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public DbSet<DistributionCenter> DistributionCenter { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DistributionCenterMapping());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        .UseNpgsql().UseSnakeCaseNamingConvention();
}