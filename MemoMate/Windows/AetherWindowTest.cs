using System.Numerics;
using AetherLib.GUI.Windows;
using ImGuiNET;

namespace MemoMate.Windows;

public class AetherWindowTest : AetherWindow
{
    public override string Title { get; set; } = "AetherWindow Test";
    public override ImGuiWindowFlags Flags { get; set; } = ImGuiWindowFlags.NoResize;

    public override WindowSizeConstraints SizeConstraints { get; set; }
        = new()
        {
            MinimumSize = new Vector2(250, 250),
            MaximumSize = new Vector2(250, 250)
        };
    
    public override bool OnlyOneAllowed { get; set; }

    public override void Draw()
    {
        base.Draw();
        ImGui.Text("Maybe this window works.");
    }
}