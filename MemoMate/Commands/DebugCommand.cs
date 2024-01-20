using AetherLib.Commands;
using AetherLib.GUI.Windows;
using MemoMate.Windows;

namespace MemoMate.Commands;

public class DebugCommand : AetherCommand
{
    public override string Name { get; set; } = "/mmdbg";
    public override string Description { get; set; } = "Open up debugging tools for MemoMate";
    public override bool ShowInHelpText { get; set; } = false;

    private DebugWindow debugWindow;
    
    public DebugCommand()
    {
        debugWindow = new DebugWindow();
        AetherWindowSystem.CreateWindow(debugWindow);
    }
    
    public override void Execute(string args)
    {
        debugWindow.IsOpen = true;
    }
}