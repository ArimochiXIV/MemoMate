using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace MemoMate.Windows;

public class TraditionalWindow : Window
{
    public TraditionalWindow() : base("MemoMate Window Test", ImGuiWindowFlags.NoResize)
    {
        SizeConstraints = new WindowSizeConstraints()
        {
            MinimumSize = new Vector2(250, 250),
            MaximumSize = new Vector2(250, 250)
        };
    }

    public override void Draw()
    {
        ImGui.Text("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }
}