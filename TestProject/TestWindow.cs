using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace TestProject;

public class TestWindow : Window
{
    public TestWindow() : base("Test Window aaaaaa", ImGuiWindowFlags.NoResize)
    {
        var size = new Vector2(250, 250);
        SizeConstraints = new WindowSizeConstraints()
        {
            MinimumSize = size,
            MaximumSize = size
        };
    }

    public override void Draw()
    {
        ImGui.Text("Test Text");
    }
}