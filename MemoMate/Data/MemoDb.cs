using System.Diagnostics;
using LiteDB;

namespace MemoMate.Data;

public static class MemoDb
{
    private static string FilePath => Path.Join(
            Services.Instance.PluginInterface.GetPluginConfigDirectory(),
            "MemoMate.db"
        );
    
    private static string ConnectionString => $"Filename={FilePath}; Connection=shared";

    public static bool Exists(string name, uint worldId)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        using var db = new LiteDatabase(ConnectionString);
        var col = db.GetCollection<MemoModel>("memos");
        
        var exists = col.Exists(m => m.Id == MemoModel.GetId(name, worldId));
        Logger.Debug($"Checking existence (\"{name}\", {worldId}) == {exists}");
        
        stopwatch.Stop();
        Logger.Debug($"[PERF] {nameof(Exists)} - {stopwatch.ElapsedMilliseconds}ms");
        
        return exists;
    }
    
    public static MemoModel Get(string name, uint worldId)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Logger.Debug($"Getting record (\"{name}\", {worldId})");
        
        if (!Exists(name, worldId))
            return new MemoModel
            {
                Name = name,
                WorldId = worldId,
            };;
        
        using var db = new LiteDatabase(ConnectionString);
        var col = db.GetCollection<MemoModel>("memos");
        var memo = col.FindOne(m => m.Id == MemoModel.GetId(name, worldId));

        stopwatch.Stop();
        Logger.Debug($"[PERF] {nameof(Get)} - {stopwatch.ElapsedMilliseconds}ms");

        return memo;
    }

    public static MemoModel Create(string name, uint worldId)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        if (Exists(name, worldId))
            return Get(name, worldId);
        
        using var db = new LiteDatabase(ConnectionString);
        var col = db.GetCollection<MemoModel>("memos");
        
        var memo = new MemoModel
        {
            Name = name,
            WorldId = worldId,
        };
        
        col.Insert(memo);

        stopwatch.Stop();
        Logger.Debug($"[PERF] {nameof(Create)} - {stopwatch.ElapsedMilliseconds}ms");
        
        return memo;
    }

    public static void Upsert(MemoModel memoModel)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        using var db = new LiteDatabase(ConnectionString);
        var col = db.GetCollection<MemoModel>("memos");

        if (Exists(memoModel.Name, memoModel.WorldId))
        {
            Logger.Info($"Memo target already exists, updating.");
            col.Update(memoModel);
        }
        else
        {
            Logger.Info($"Memo target doesn't exist, inserting.");
            col.Insert(memoModel);
        }
        
        stopwatch.Stop();
        Logger.Debug($"[PERF] {nameof(Upsert)} - {stopwatch.ElapsedMilliseconds}ms");
    }

    public static int Count()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        using var db = new LiteDatabase(ConnectionString);
        var col = db.GetCollection<MemoModel>("memos");
        var count = col.Count();
        
        stopwatch.Stop();
        Logger.Debug($"[PERF] {nameof(Count)} - {stopwatch.ElapsedMilliseconds}ms");

        return count;
    }

    public static void Delete(string name, uint worldId)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        if (Exists(name, worldId))
        {
            using var db = new LiteDatabase(ConnectionString);
            var col = db.GetCollection<MemoModel>("memos");
            col.Delete(MemoModel.GetId(name, worldId));
        }
        
        stopwatch.Stop();
        Logger.Debug($"[PERF] {nameof(Delete)} - {stopwatch.ElapsedMilliseconds}ms");
    }
}