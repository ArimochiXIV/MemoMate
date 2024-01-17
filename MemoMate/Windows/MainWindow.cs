using AetherLib.GUI.Windows;
using AetherLib.Helpers;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace MemoMate.Windows;

public class MainWindow : AetherWindow
{
    public override string Title { get; set; }
    public override ImGuiWindowFlags Flags { get; set; }
    public override WindowSizeConstraints SizeConstraints { get; set; }
    public override bool OnlyOneAllowed { get; set; } = true;
}