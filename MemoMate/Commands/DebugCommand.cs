using AetherLib.Commands;
using AetherLib.GUI.Windows;
using MemoMate.Windows;

namespace MemoMate.Commands;

public class DebugCommand : AetherCommand
{
    public override string Name { get; set; } = "/memodbg";
    public override string Description { get; set; } = "Open up debugging tools for MemoMate";
    public override bool ShowInHelpText { get; set; } = true;

    public override void Execute(string args)
    {
        AetherWindowSystem.CreateWindow(new DebugWindow());
    }
}