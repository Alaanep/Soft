namespace ABC.Aids;

public static class GetNameSpace {
    public static string? OfType(Object? obj) => Safe.Run(() => obj?.GetType()?.Namespace??string.Empty, String.Empty);
}