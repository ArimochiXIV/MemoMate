using Dalamud.Interface.Windowing;
using Dalamud.Plugin;

namespace TestProject;

public class Plugin : IDalamudPlugin
{
    public Services Services;
    public TestWindow TestWindow;
    public WindowSystem WindowSystem = new ("TestProject");

    public Plugin(DalamudPluginInterface pluginInterface)
    {
        Services = pluginInterface.Create<Services>();
        Services.PluginLog.Info("Loaded Test Plugin!");
        
        TestWindow = new TestWindow();
        WindowSystem.AddWindow(TestWindow);
        
        pluginInterface.UiBuilder.Draw += WindowSystem.Draw;
        pluginInterface.UiBuilder.OpenConfigUi += () => TestWindow.IsOpen = true;
        
        TestWindow.IsOpen = true;
    }
    
    public void Dispose() => WindowSystem.RemoveAllWindows();
}