using Microsoft.EntityFrameworkCore;

namespace MemoMate.Data;

public class MemoContext : DbContext
{
    private const string DatabaseFileName = "MemoMate.db";

    // Using anything that references Dalamud will cause adding migrations to break. 
    private string FilePath => Path.Join(
            "%appdata%/XIVLauncher/pluginConfigs/MemoMate", 
            DatabaseFileName
        );

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(FilePath);
    }
}