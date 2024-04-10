using System.Data.Common;
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
        //var connectionString = builder.GetConnectionString("debstar");
        string connectionString = "server=192.168.0.107;database=dotnetAPI;user=knutekje;password=hore23;";
 //nd it works. For MySQL use "builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        options => options.MigrationsAssembly(typeof(IncidentContext).GetTypeInfo().Assembly.GetName().Name));
        return new IncidentContext(builder.Options);
    }
}
