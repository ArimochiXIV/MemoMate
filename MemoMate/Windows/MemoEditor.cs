using Dalamud.Interface.Windowing;

namespace MemoMate.Windows;
using ImGuiNET;

public class MemoEditor : Window
{
    public static MemoEditor Instance { get; private set; }
    
    private MemoEditor() : base("Memo Editor")
    {
        
    }

    public override void Draw()
    {
        throw new NotImplementedException();
    }
}