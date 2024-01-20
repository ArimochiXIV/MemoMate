namespace MemoMate.Reflection;

public static class ObjectExtensions
{
    public static void CopyTo(this object from, object to)
    {
        if (from.GetType() != to.GetType())
            throw new Exception("Types being copied between must be the same type!");
        foreach (var prop in from.GetType().GetProperties())
        {
            if (!(prop.CanRead && prop.CanWrite))
                continue;
            prop.SetValue(to, prop.GetValue(from));
        }
    }
}