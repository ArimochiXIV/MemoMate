using Dalamud.IoC;
using Dalamud.Plugin.Services;

namespace TestProject;

public class Services
{
    [PluginService] public IPluginLog PluginLog { get; set; }
    [PluginService] public ICommandManager CommandManager { get; set; }
}