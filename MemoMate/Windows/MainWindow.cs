using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace MemoMate.Windows;

public class MainWindow : Window
{
    private static MainWindow _instance;
    public static MainWindow Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MainWindow();
                Services.Instance.WindowSystem.AddWindow(_instance);
            }
            return _instance;
        }
    }

    private MainWindow() : base("MemoMate", ImGuiWindowFlags.NoResize)
    {
        Size = new Vector2(515, 415);
    }

    public override void Draw()
    {
        ImGui.Text("MainWindow");
    }
}