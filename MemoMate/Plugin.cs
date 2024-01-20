using AetherLib.Plugin;
using Dalamud.Plugin;
using MemoMate.Windows;
using AetherLib;
using AetherLib.GUI.Windows;
using AetherLib.Logging;
using AetherLib.Modules;
using Dalamud.Configuration;
using Dalamud.Game.Text.SeStringHandling;

namespace MemoMate;

public class Plugin : AetherPlugin
{
    public static PluginConfiguration PluginConfiguration;
    public static string ConfigDirectory;
    
    public Plugin(DalamudPluginInterface pluginInterface) : base(pluginInterface)
    {
        ConfigDirectory = pluginInterface.ConfigDirectory.FullName;
        PluginConfiguration = pluginInterface.GetPluginConfig() as PluginConfiguration ?? new PluginConfiguration();
        PluginConfiguration.Initialize(pluginInterface);

    }
}