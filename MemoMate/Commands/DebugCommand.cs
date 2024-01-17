using AetherLib.Commands;
using AetherLib.GUI.Windows;
using AetherLib.Modules;
using MemoMate.Windows;

namespace MemoMate.Commands;

public class DebugCommand : AetherCommand
{
    public override string Name { get; set; } = "/memodbg";
    public override string Description { get; set; } = "Open up debugging tools for MemoMate";
    public override bool ShowInHelpText { get; set; } = true;

    private DebugWindow DebugWindow;
    
    public DebugCommand()
    {
        DebugWindow = new DebugWindow();
        AetherWindowSystem.CreateWindow(DebugWindow);
    }
    
    public override void Execute(string args)
    {
        ChatBox.AppendLine("Doing debug thing!");
        DebugWindow.IsOpen = true;
    }
}