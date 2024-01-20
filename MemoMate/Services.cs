using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace MemoMate;

public class Services
{
    public static Services Instance;
    
    public DalamudPluginInterface PluginInterface { get; set; }

    [PluginService] public IChatGui ChatGui { get; set; }
    [PluginService] public IPluginLog PluginLog { get; set; }
}
