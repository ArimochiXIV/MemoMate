using Dalamud.Game.ClientState.Objects.Enums;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.Command;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using MemoMate.Data;
using MemoMate.Windows;

namespace MemoMate.Commands;

public static class CommandCreator
{
    public static void Initialize()
    {
        Services.Instance.CommandManager.AddHandler("/memo", new CommandInfo(OnOpenEditorCommand)
        {
            HelpMessage = "Opens the memo editor for the currently-targeted player.",
            ShowInHelp = true
        });
        Services.Instance.CommandManager.AddHandler("/memos", new CommandInfo(OnOpenMainWindowCommand)
        {
            HelpMessage = "Opens the main MemoMate window.",
            ShowInHelp = true
        });
        Services.Instance.CommandManager.AddHandler("/mm", new CommandInfo(OnDidDebugCommand)
        {
            HelpMessage = "Various debugging commands.",
            ShowInHelp = false
        });
    }

    private static void OnOpenEditorCommand(string name, string args)
    {
        if (!TryOpenEditor())
            OnOpenMainWindowCommand(name, args);
    }

    private static bool TryOpenEditor()
    {
        var localPlayer = Services.Instance.ClientState.LocalPlayer;
        if (localPlayer == null)
            return false;
        
        var targetId = localPlayer.TargetObjectId;
        if (targetId == 0)
            return false;
        
        var gameObject = Services.Instance.ObjectTable.Single(o => o.ObjectId == targetId);
        if (gameObject.ObjectKind != ObjectKind.Player)
            return false;
        
        var targetPlayer = (PlayerCharacter)gameObject;
        MemoEditor.OpenMemo(targetPlayer.Name.TextValue, targetPlayer.HomeWorld.Id);
        
        return true;
    }
    
    private static void OnOpenMainWindowCommand(string name, string args)
    {
        Services.Instance.ChatGui.Print(new SeString(new TextPayload("Sorry, this command is not yet implemented.")), "MemoMate");
        // MainWindow.Instance.IsOpen = true;
    }
    
    private static void OnDidDebugCommand(string name, string args)
    {
        if (args == string.Empty)
        {
            OnOpenMainWindowCommand(name, args);
            return;
        }
        
        var argParts = args.Split(" ");
        switch (argParts[0])
        {
            case "count":
                Services.Instance.ChatGui.Print(new SeString(new TextPayload($"Memo Count: {MemoDb.Count()}")), "MemoMate");
                break;
        }
    }
    
    
}