using Dalamud.ContextMenu;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using MemoMate.Windows;

namespace MemoMate.Context;

public static class MemoContextAction
{
    // TODO: Add color difference for when person has a memo stored.
    private static SeString ActionName
    {
        get
        {
            var seStringBuilder = new SeStringBuilder();

            seStringBuilder.AddUiForeground(31);
            seStringBuilder.Append(SeIconChar.BoxedLetterM.ToIconString());
            seStringBuilder.AddUiForegroundOff();
            seStringBuilder.Append(" Open Memo");
            
            return seStringBuilder.BuiltString;
        }
    }

    private static DalamudContextMenu _contextMenu;

    private static GameObjectContextMenuItem MenuItem => new (ActionName, OnClick);

    public static void Initialize()
    {
        _contextMenu = new DalamudContextMenu(Services.Instance.PluginInterface);
        _contextMenu.OnOpenGameObjectContextMenu += DecideAddItem;
    }

    private static void DecideAddItem(GameObjectContextMenuOpenArgs args)
    {
        if (args.ObjectWorld == 0)
            return;
        args.AddCustomItem(MenuItem);
    }

    private static void OnClick(GameObjectContextMenuItemSelectedArgs args)
    {
        var name = args.Text.TextValue;
        var worldId = args.ObjectWorld;
        MemoEditor.OpenMemo(name, worldId);
    }

    public static void Dispose()
    { 
        _contextMenu.Dispose();
    }
}