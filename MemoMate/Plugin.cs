using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using MemoMate.Commands;
using MemoMate.Context;

namespace MemoMate;

public class Plugin : IDalamudPlugin
{
    public Plugin(DalamudPluginInterface pluginInterface)
    {
        Services.Instance = pluginInterface.Create<Services>();
        Services.Instance.PluginInterface = pluginInterface;
        Services.Instance.WindowSystem = new WindowSystem("MemoMate");
        Services.Instance.PluginInterface.UiBuilder.Draw += Services.Instance.WindowSystem.Draw;

        CommandCreator.Initialize();
        MemoContextAction.Initialize();
    }

    public void Dispose()
    {
        Services.Instance.WindowSystem.RemoveAllWindows();
        MemoContextAction.Dispose();
        
    }
}