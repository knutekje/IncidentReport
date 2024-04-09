using System.Reflection;
using IncidentReport.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IncidentReport.Data;

public class IncidentContext : DbContext
{
    public IncidentContext(DbContextOptions<IncidentContext> options)
        : base(options)
    {
    }

    public DbSet<IncidentCase> IncidentCases { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
       base.OnModelCreating(builder);
    }
    
}
public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<IncidentContext>
{
    private readonly IConfiguration _configuration;
    public TemporaryDbContextFactory() { }
    public TemporaryDbContextFactory(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public IncidentContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<IncidentContext>();
        builder.UseSqlServer("DebstarConnection",
        optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(IncidentContext).GetTypeInfo().Assembly.GetName().Name));
        return new IncidentContext(builder.Options);
    }
}
