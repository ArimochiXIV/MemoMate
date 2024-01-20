namespace MemoMate.Models;

public class PlayerMemo
{
    public string Name { get; init; }
    public uint WorldId { get; init; }
    public string Note { get; set; } = string.Empty;
    public DateTime LastSeen { get; set; }
    public DateTime FirstSeen { get; set; }
    public DateTime LastUpdated { get; set; }

    public static PlayerMemo Get(string name, uint worldId)
    {
        return MemoStorage.GetOrCreateMemo(name, worldId);
    }

    public void Save()
    {
        MemoStorage.SaveMemo(this);
    }
}