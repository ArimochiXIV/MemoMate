using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using MemoMate.Changelog;

namespace MemoMate.Windows;

public class ChangelogWindow : Window
{
    private static ChangelogWindow _instance;
    public static ChangelogWindow Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ChangelogWindow();
                Services.Instance.WindowSystem.AddWindow(_instance);
            }
            return _instance;
        }
    }

    private bool isFirstOpen = true;

    public ChangelogWindow() : base("MemoMate Changelog")
    {
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(250, 250),
            MaximumSize = new Vector2(800, 800)
        };
    }

    public override void Draw()
    {
        if (isFirstOpen)
        {
            var screenSize = ImGui.GetIO().DisplaySize;
            var windowSize = ImGui.GetWindowSize();
            ImGui.SetWindowPos(screenSize / 2 - windowSize / 2);
            isFirstOpen = false;
        }

        var history = ChangeHistory.Changes;
        RenderChangelog(history[0], true);
        for (var i = 1; i < history.Length; i++)
            RenderChangelog(history[i]);
    }

    private void RenderChangelog(ChangelogEntry entry, bool isLatest = false)
    {
        var flags = isLatest ? ImGuiTreeNodeFlags.DefaultOpen : ImGuiTreeNodeFlags.None;
        var title = $"{(isLatest ? "[LATEST] " : "")}Version {entry.VersionString}";
        if (ImGui.CollapsingHeader(title, flags))
        {
            ImGui.Indent(25);
            ImGui.TextWrapped(string.Join('\n', entry.Changes));
            ImGui.Unindent(25);
        }
    }
}