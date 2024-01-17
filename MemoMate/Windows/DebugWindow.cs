using AetherLib.GUI.Windows;
using AetherLib.Helpers;
using ImGuiNET;

namespace MemoMate.Windows;

public class DebugWindow : AetherWindow
{
    public override string Title { get; set; } = "MemoMate Debug Tools";
    public override ImGuiWindowFlags Flags { get; set; }
    public override WindowSizeConstraints SizeConstraints { get; set; }
    public override bool OnlyOneAllowed { get; set; } = true;

    public override void Draw()
    {
        base.Draw();
        ImGui.Text("Debug window!");
    }
}