using Dalamud.ContextMenu;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using MemoMate.Data;
using MemoMate.Windows;

namespace MemoMate.Context;

public static class MemoContextAction
{
    private const ushort NoMemoColor = 31;
    private const ushort HasMemoColor = 60;

    private static DalamudContextMenu _contextMenu;

    public static void Initialize()
    {
        _contextMenu = new DalamudContextMenu(Services.Instance.PluginInterface);
        _contextMenu.OnOpenGameObjectContextMenu += DecideAddItem;
    }

    private static SeString GetActionName(string name, uint worldId)
    {
        var hasMemo = MemoDb.Exists(name, worldId);
        
        var seStringBuilder = new SeStringBuilder();

        seStringBuilder.AddUiForeground(hasMemo ? HasMemoColor : NoMemoColor);
        seStringBuilder.Append(SeIconChar.BoxedLetterM.ToIconString());
        seStringBuilder.AddUiForegroundOff();
        seStringBuilder.Append($" {(hasMemo ? "Open" : "New")} Memo");
            
        return seStringBuilder.BuiltString;
    }

    private static void DecideAddItem(GameObjectContextMenuOpenArgs args)
    {
        Logger.Debug($"Context menu {{Text=\"{args.Text}\", World={args.ObjectWorld}, ID={args.ObjectId:X}}}");
        
        // Ignore non-PC
        if (args.ObjectWorld == 0 || args.ObjectWorld == ushort.MaxValue)
            return;
        
        // Ignore LocalPlayer
        var localPlayer = Services.Instance.ClientState.LocalPlayer;
        if (args.ObjectId == localPlayer.ObjectId)
            return;
        if (args.Text.TextValue == localPlayer.Name.TextValue && args.ObjectWorld == localPlayer.HomeWorld.Id)
            return;

        var name = GetActionName(args.Text.TextValue, args.ObjectWorld);
        args.AddCustomItem(new GameObjectContextMenuItem(name, OnClick));
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