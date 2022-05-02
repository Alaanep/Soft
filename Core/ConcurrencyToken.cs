namespace ABC.Core {
    public static class ConcurrencyToken {
        public static string ToStr(byte[]? token=null) {
            var s = string.Empty;
            foreach (var b in token?? Array.Empty<byte>()) s += b;
            return s;
        }
    }
}
