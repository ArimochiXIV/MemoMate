using System.Numerics;
using Dalamud.Interface.Windowing;
using MemoMate.Data;

namespace MemoMate.Windows;
using ImGuiNET;

public class MemoEditor : Window
{
    private const int SavedHintTimeMs = 2000;
    public static MemoEditor Instance { get; private set; }

    private Memo memo;
    private string memoText = string.Empty;
    private bool isFirstOpen = false;

    private Vector2 buttonSize = new(80, 25);

    private long lastSaveTime;
    
    private MemoEditor() : base("Memo Editor", ImGuiWindowFlags.NoResize | ImGuiWindowFlags.AlwaysAutoResize)
    {
        if (Instance != null)
        {
            Logger.Error("An instance of MemoEditor already exists!");
            return;
        }
        
        Instance = this;
        Instance.isFirstOpen = true;
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
        WindowName = $"Memo Editor [{memo.Name}]###memo-editor";

        if (isFirstOpen)
        {
            var screenSize = ImGui.GetIO().DisplaySize;
            var windowSize = ImGui.GetWindowSize();
            ImGui.SetWindowPos(screenSize / 2 - windowSize / 2);
            isFirstOpen = false;
        }
        
        ImGui.Text($"Custom Memo:");
        ImGui.InputTextMultiline("###memo-editor", ref memoText, 1000, new Vector2(350, 100));

        var inSaveCooldown = DateTimeOffset.Now.ToUnixTimeMilliseconds() - lastSaveTime <= SavedHintTimeMs;

        if (inSaveCooldown)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(0, 1, 0, 1));
            ImGui.BeginDisabled();
            ImGui.Button("Saved!", buttonSize);
            ImGui.EndDisabled();
            ImGui.PopStyleColor();
        }
        else if (ImGui.Button("Save Memo", buttonSize))
        {
            SaveMemo();
        }
        
    }

    private void SaveMemo()
    {
        memo.MemoText = memoText;
        MemoDb.Upsert(memo);
        
        lastSaveTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}