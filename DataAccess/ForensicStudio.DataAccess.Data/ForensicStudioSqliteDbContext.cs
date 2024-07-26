using Microsoft.EntityFrameworkCore;

namespace ForensicStudio.DataAccess.Data;

public class ForensicStudioSqliteDbContext : ForensicStudioDbContext
{
    private string DbPath { get; }

    public ForensicStudioSqliteDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "ForensicStudio.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}