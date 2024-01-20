using System.Diagnostics;
using AetherLib.Extensions;
using AetherLib.GUI.Controls;
using ImGuiNET;

namespace MemoMate.Windows.Tabs;

public class SettingsTab : TabContent
{
    public override string Title { get; set; } = "Settings";
    public override void Draw()
    {
        ImGui.Text($"Memo Count: {MemoStorage.Memos.Count}");
        ImGui.Text($"Data Size: {(MemoStorage.GetDiskSizeBytes() / 1000f).Rounded()}kb");
        
        if (ImGui.Button("Load From Disk"))
        {
            MemoStorage.RefreshFromDisk();
        }

        if (ImGui.Button("Reset Memos"))
        {
            MemoStorage.ResetStorage();
        }
        
        if (ImGui.Button("Open Data Directory"))
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = Plugin.ConfigDirectory,
                FileName = "explorer.exe"
            };

            Process.Start(startInfo);
        }
    }
}