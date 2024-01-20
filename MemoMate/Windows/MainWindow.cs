using System.Numerics;
using AetherLib.GUI.Controls;
using AetherLib.GUI.Windows;
using ImGuiNET;
using MemoMate.Windows.Tabs;

namespace MemoMate.Windows;

public class MainWindow : AetherWindow
{
    public override string Title { get; set; } = "MemoMate";
    public override ImGuiWindowFlags Flags { get; set; } = ImGuiWindowFlags.NoResize;

    // TODO: See if these need to be adjusted once GUI is more laid-out.
    public override WindowSizeConstraints SizeConstraints { get; set; }
        = new()
        {
            MinimumSize = new Vector2(400, 350),
            MaximumSize = new Vector2(500, 500)
        };

    private TabPanel tabPanel = new()
    {
        Tabs = new TabContent[]
        {
            new NearbyTab(),
            new MemosTab(),
            new SettingsTab(),
        }
    };
    
    public override void Draw()
    {
        base.Draw();
        tabPanel.Draw();
    }
}