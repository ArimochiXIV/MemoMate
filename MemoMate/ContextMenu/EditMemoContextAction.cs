using AetherLib.ContextMenu;
using Dalamud.ContextMenu;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using MemoMate.Windows.Tabs;

namespace MemoMate.ContextMenu;

public class EditMemoContextAction : GameObjectContextAction
{
    private const ushort NoMemoColor = 31;
    private const ushort HasMemoColor = 43;
    
    public override SeString GetName(GameObjectContextMenuOpenArgs args)
    {
        var hasMemo = MemoStorage.HasMemo(args.Text.TextValue, args.ObjectWorld);
        
        var seStringBuilder = new SeStringBuilder();

        seStringBuilder.AddUiForeground(hasMemo ? HasMemoColor : NoMemoColor);
        seStringBuilder.Append(SeIconChar.BoxedLetterM.ToIconString());
        seStringBuilder.AddUiForegroundOff();
        
        seStringBuilder.Append(" Open Memo");

        return seStringBuilder.BuiltString;
    }

    public override bool ShouldShow(GameObjectContextMenuOpenArgs args) 
        => args.ObjectWorld != 0;

    public override void OnClick(GameObjectContextMenuItemSelectedArgs args)
    {
        MemoWindow.OpenToPlayer(args.Text.TextValue, args.ObjectWorld);
    }
}