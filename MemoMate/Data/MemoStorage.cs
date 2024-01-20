using System.Text.Json;
using AetherLib.Logging;
using AetherLib.Modules;
using Dalamud.Game.Text.SeStringHandling;
using MemoMate.Models;

namespace MemoMate;

public static class MemoStorage
{
    private static readonly string FilePath = Plugin.ConfigDirectory + "/MemoMateStorage.json";
    
    public static bool FailedToLoad = true;
    public static List<PlayerMemo> Memos { get; private set; }

    static MemoStorage()
    {
        RefreshFromDisk();
    }
    
    public static PlayerMemo GetOrCreateMemo(string name, uint worldId)
    {
        var memo = Memos.SingleOrDefault(m => m.Name == name && m.WorldId == worldId);
        
        if (memo == null)
        {
            AetherLog.Info($"Creating new memo entry for {name}");
            memo = new PlayerMemo
            {
                Name = name,
                WorldId = worldId
            };
        }
        
        Memos.Add(memo);
        
        return memo;
    }

    public static bool HasMemo(string name, uint homeWorldId) 
        => Memos.Any(m => m.Name == name && m.WorldId == homeWorldId);

    public static long GetDiskSizeBytes()
    {
        if (!File.Exists(FilePath))
            return 0;
        return new FileInfo(FilePath).Length;
    }

    public static void RefreshFromDisk()
    {
        if (!File.Exists(FilePath))
        {
            AetherLog.Info($"Created storage file at [{FilePath}]");
            using (var stream = File.Create(FilePath))
            using (var writer = new StreamWriter(stream))
                writer.Write("[]");
        }
        AetherLog.Info($"Loading existing memos from disk.");
        try
        {
            Memos = JsonSerializer.Deserialize<List<PlayerMemo>>(File.ReadAllText(FilePath));
            if (Memos == null)
                throw new Exception("Memos was null after deserializing from disk!");
            AetherLog.Info($"Deserialized {Memos.Count} memos!");
        }
        catch (Exception e)
        {
            FailedToLoad = true;
            AetherLog.Error("Failed to load memos from disk.");
            AetherLog.Exception(e);
            
            var seString = new SeStringBuilder();
            seString.Append("[MemoMate] ");
            seString.AddUiForeground(544);
            seString.Append("An error occured when trying to load existing memos. ");
        
            ChatBox.AppendLine(seString.BuiltString);
        }
    }

    public static void ResetStorage()
    {
        if (File.Exists(FilePath))
            File.Delete(FilePath);
        
        AetherLog.Warn("Memo storage file was deleted!");
        
        var seString = new SeStringBuilder();
        seString.Append("[MemoMate] ");
        seString.AddUiForeground(544);
        seString.Append("Your memo storage was wiped!");
        
        ChatBox.AppendLine(seString.BuiltString);
    }

    public static void WriteToDisk()
    {
        if (!File.Exists(FilePath))
            File.Create(FilePath);
        
        try
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(Memos));
            AetherLog.Info("Wrote to disk!");
        }
        catch (Exception e)
        {
            AetherLog.Error($"Failed to write to disk! {e.Message}");
            AetherLog.Error(e.StackTrace ?? "No StackTrace available!");
            
            var seString = new SeStringBuilder();
            seString.Append("[MemoMate] ");
            seString.AddUiForeground(544);
            seString.Append("Failed to save memos!");
            ChatBox.AppendError(seString.BuiltString);
        }
    }

    private static void CopyProperties(PlayerMemo from, PlayerMemo to)
    {
        foreach (var prop in from.GetType().GetProperties().Where(p => p.CanWrite && p.CanRead))
            prop.SetValue(to, prop.GetValue(from));
    }

    public static void SaveMemo(PlayerMemo memo)
    {
        var savedMemo = GetOrCreateMemo(memo.Name, memo.WorldId);
        CopyProperties(memo, savedMemo);
        WriteToDisk();
    }
}
