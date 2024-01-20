using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace MemoMate;

public class Services
{
    public static Services Instance;
    
    public DalamudPluginInterface PluginInterface { get; set; }
    public WindowSystem WindowSystem { get; set; }
    
    [PluginService] public IChatGui ChatGui { get; set; }
    [PluginService] public IClientState ClientState { get; set; }
    [PluginService] public ICommandManager CommandManager { get; set; }
    [PluginService] public IObjectTable ObjectTable { get; set; }
    [PluginService] public IPluginLog PluginLog { get; set; }
}
