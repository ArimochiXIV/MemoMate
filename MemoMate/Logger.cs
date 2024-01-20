namespace MemoMate;

public static class Logger
{
    public static void Info(string message) => Services.Instance.PluginLog.Info(message);
    public static void Debug(string message) => Services.Instance.PluginLog.Debug(message);
    public static void Verbose(string message) => Services.Instance.PluginLog.Verbose(message);
    public static void Warn(string message) => Services.Instance.PluginLog.Warning(message);
    public static void Error(string message) => Services.Instance.PluginLog.Error(message);

    public static void Exception(string message, Exception e)
    {
        Error($"EXCEPTION! {message} ({e.Message})");
        Error(e.StackTrace);
    }
}