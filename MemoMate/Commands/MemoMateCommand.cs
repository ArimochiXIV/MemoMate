using AetherLib.Commands;
using AetherLib.GUI.Windows;
using MemoMate.Windows;

namespace MemoMate.Commands;

public class MemoMateCommand : AetherCommand
{
    public override string Name { get; set; } = "/memo";
    public override string Description { get; set; } = "Opens the main MemoMate window.";
    public override bool ShowInHelpText { get; set; }

    private MainWindow mainWindow;
    
    public MemoMateCommand()
    {
        mainWindow = new MainWindow();
        AetherWindowSystem.CreateWindow(mainWindow);
    }
    
    public override void Execute(string args)
    {
        mainWindow.IsOpen = true;
    }
}