using Microsoft.EntityFrameworkCore;

namespace MemoMate.Data;

public static class MigrationRunner
{
    public static void RunMigrations()
    {
        Logger.Debug("Checking for DB migrations.");
        var context = new MemoContext();
        var pending = context.Database.GetPendingMigrations().ToList();
        if (!pending.Any())
        {
            Logger.Debug("No pending DB migrations!");
            return;
        }
        
        Logger.Debug($"Running {pending.Count} migrations.");
        
    }
}