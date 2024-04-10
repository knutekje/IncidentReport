using System.Reflection;
using IncidentReport.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IncidentReport.Areas.Identity.Data;

public class IncidentReportIdentityDbContext : IdentityDbContext<IdentityUser>
{
    public IncidentReportIdentityDbContext(DbContextOptions<IncidentReportIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<IncidentReportIdentityDbContext>
{
    private readonly IConfiguration _configuration;
    public TemporaryDbContextFactory() { }
    public TemporaryDbContextFactory(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public IncidentReportIdentityDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<IncidentReportIdentityDbContext>();
        //var connectionString = builder.GetConnectionString("debstar");
        string connectionString = "server=192.168.0.107;database=dotnetAPI;user=knutekje;password=hore23;";
 //nd it works. For MySQL use "builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        options => options.MigrationsAssembly(typeof(IncidentReportIdentityDbContext).GetTypeInfo().Assembly.GetName().Name));
        return new IncidentReportIdentityDbContext(builder.Options);
    }
}

