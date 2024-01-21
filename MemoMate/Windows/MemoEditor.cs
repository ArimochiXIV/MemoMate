using System.Numerics;
using Dalamud.Interface.Windowing;
using MemoMate.Data;

namespace MemoMate.Windows;
using ImGuiNET;

public class MemoEditor : Window
{
    public static MemoEditor Instance { get; private set; }

    private Memo memo;
    private string memoText = string.Empty;
    
    private MemoEditor() : base("Memo Editor", ImGuiWindowFlags.NoResize | ImGuiWindowFlags.AlwaysAutoResize)
    {
        if (Instance != null)
        {
            Logger.Error("An instance of MemoEditor already exists!");
            return;
        }
        
        Instance = this;
        Size = new Vector2(315, 215);
    }

    public static void OpenMemo(string name, uint worldId) => OpenMemo(MemoDb.Get(name, worldId));
    public static void OpenMemo(Memo memo)
    {
        if (Instance == null)
        {
            Instance = new MemoEditor();
            Services.Instance.WindowSystem.AddWindow(Instance);
        }

        if (memo == null)
            throw new ArgumentNullException(nameof(memo));
        
        Instance.memo = memo;
        Instance.memoText = memo.MemoText ?? string.Empty;
        Instance.IsOpen = true;
    }

    public override void Draw()
    {
        WindowName = $"Memo Editor [{memo.Name}]";

        ImGui.Text($"Custom Memo:");
        ImGui.InputTextMultiline("###memo-editor", ref memoText, 1000, new Vector2(350, 100));
        if (ImGui.Button("Save Memo"))
            SaveMemo();
    }

    private void SaveMemo()
    {
        memo.MemoText = memoText;
        MemoDb.Upsert(memo);
    }
}