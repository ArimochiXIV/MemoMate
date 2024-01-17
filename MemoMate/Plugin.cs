using AetherLib.Plugin;
using Dalamud.Plugin;
using MemoMate.Windows;
using AetherLib;
using AetherLib.GUI.Windows;

namespace MemoMate;

public class Plugin : AetherPlugin
{
    public Plugin(DalamudPluginInterface pluginInterface) : base(pluginInterface)
    {
        // var window = new TraditionalWindow();
        // var aetherWindow = new AetherWindowTest();
        
        // var windowSystem = new WindowSystem();
        // windowSystem.AddWindow(window);
        // windowSystem.AddWindow(aetherWindow);

        // var windowSystem = AetherLib.AetherLib.Instance.WindowSystem;
        // windowSystem.AddWindow(aetherWindow);
        
        // AetherWindowSystem.CreateWindow(aetherWindow);
        
        // pluginInterface.UiBuilder.Draw += windowSystem.Draw;
        // pluginInterface.UiBuilder.OpenConfigUi += () => aetherWindow.IsOpen = true;
    }
}