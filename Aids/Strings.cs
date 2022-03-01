namespace ABC.Aids;

public static class Strings {
    public static string? Remove(this string fromString, string theString) => Safe.Run(() => fromString?.Replace(theString, string.Empty), string.Empty);
    public static bool IsRealTypeName(this string? s) => Safe.Run(() => s?.All(x=>x.IsNameChar()) ?? false);
}