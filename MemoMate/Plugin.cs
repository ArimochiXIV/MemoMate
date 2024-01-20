using Dalamud.Plugin;
using MemoMate.Data;

namespace MemoMate;

public class Plugin : IDalamudPlugin
{
    public Plugin(DalamudPluginInterface pluginInterface)
    {
        Services.Instance = pluginInterface.Create<Services>();
        Services.Instance.PluginInterface = pluginInterface;
        MigrationRunner.RunMigrations();
    }
    
    public void Dispose()
    {
        
    }
}