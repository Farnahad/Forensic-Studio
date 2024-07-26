using ForensicStudio.DataAccess.Model.Windows;
using Microsoft.EntityFrameworkCore;

namespace ForensicStudio.DataAccess.Data;

public class ForensicStudioDbContext : DbContext
{
    public DbSet<Vulnerability> Vulnerabilities { get; set; }
    public DbSet<VulnerabilitySource> VulnerabilitySources { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}