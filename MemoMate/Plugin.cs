using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using MemoMate.Commands;
using MemoMate.Context;
using MemoMate.Data;

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
        
        Services.Instance.PluginLog.Info($"Loaded {MemoDb.Count()} memos.");
    }

    public void Dispose()
    {
        Services.Instance.WindowSystem.RemoveAllWindows();
        MemoContextAction.Dispose();
    }
}