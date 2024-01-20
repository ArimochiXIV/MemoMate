namespace MemoMate.Data;

public class Memo
{
    public string Name { get; set; }
    public uint WorldId { get; set; }
    public string MemoText { get; set; }

    public static Memo Get(string name, uint worldId)
    {
        return default;
    }

    public static void Save()
    {
        
    }
}