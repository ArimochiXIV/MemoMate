// using AetherLib.Helpers.Configuration;

using Dalamud.Configuration;
using Dalamud.Plugin;

namespace MemoMate;

public class PluginConfiguration : IPluginConfiguration
{
    private DalamudPluginInterface pluginInterface;
    
    public int Version { get; set; } = 1;

    public float DetectionRadius { get; set; } = 3f;
    public float MinimumFacingPercent { get; set; } = 0.97f;
    
    public void Initialize(DalamudPluginInterface pluginInterface)
    {
        this.pluginInterface = pluginInterface;
    }

    public void Save()
    {
        pluginInterface.SavePluginConfig(this);
    }
}
