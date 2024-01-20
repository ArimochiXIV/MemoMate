using AetherLib.GUI.Controls;
using ImGuiNET;

namespace MemoMate.Windows.Tabs;

public class MemosTab : TabContent
{
    public override string Title { get; set; } = "Memos";
    
    public override void Draw()
    {
        ImGui.Text("Memos");
    }
}