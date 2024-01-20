using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using MemoMate.Reflection;

namespace MemoMate.Data;

public class Memo
{
    public string Id => GetId(Name, WorldId);
    public string Name { get; set; }
    public uint WorldId { get; set; }

    public string MemoText { get; set; }

    public static string GetId(string name, uint worldId) 
        => string.Join(
            "",
            MD5.Create().ComputeHash(
                Encoding.ASCII.GetBytes($"{name}@{worldId}")
            ).Select(b => $"{b:X2}")
        );
}