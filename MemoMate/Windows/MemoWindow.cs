using System.Numerics;
using AetherLib.GUI.Windows;
using AetherLib.Logging;
using AetherLib.Modules;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using MemoMate.Models;

namespace MemoMate.Windows.Tabs;


// TODO: Simplify the data handling here to just keep a memo object or something.

public class MemoWindow : Window
{
    private static string GetWindowId(string name) => $"Memo Editor [{name}]###memo-window";

    private PlayerMemo currentPlayerMemo;
    
    private string memoText = string.Empty;
    
    public static MemoWindow Instance { get; private set; }
    
    private MemoWindow() : base("Memo Window", ImGuiWindowFlags.NoResize)
    {
        if (Instance != null)
        {
            AetherLog.Error("MemoWindow created more than once!");
            return;
        }
        
        Size = new Vector2(315, 215);

        Instance = this;
    }
    
    private static void InitializeWindow()
    {
        if (Instance != null)
            return;
        var window = new MemoWindow();
        AetherLib.AetherLib.Instance.WindowSystem.AddWindow(window);
    }
    
    public static void OpenToPlayer(string name, uint worldId)
    {
        if (Instance == null)
            InitializeWindow();
        Instance.currentPlayerMemo = PlayerMemo.Get(name, worldId);
        Instance.memoText = Instance.currentPlayerMemo.Note;
        Instance.IsOpen = true;
        Instance.WindowName = GetWindowId(name);
    }

    public override void Draw()
    {
        ImGui.Text($"Custom Memo:");
        ImGui.InputTextMultiline("###memo-editor", ref memoText, 1000, new Vector2(300, 125));
        if (ImGui.Button("Save Memo"))
            SaveMemo();
    }

    private void SaveMemo()
    {
        currentPlayerMemo.Note = memoText;
        currentPlayerMemo.Save();
    }
}