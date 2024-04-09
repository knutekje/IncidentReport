using IncidentReport.Model;
using Microsoft.EntityFrameworkCore;

namespace IncidentReport.Data;

public class IncidentContext : DbContext
{
    public IncidentContext(DbContextOptions<IncidentContext> options)
        : base(options)
    {
    }

    public DbSet<Incident> Incidents { get; set; } = null!;
}
