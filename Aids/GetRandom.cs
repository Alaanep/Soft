using System;

namespace ABC.Aids;

public static class GetRandom {
    private static void minFirst<T>(ref T min, ref T max) where T : IComparable<T>
    {
        if(min.CompareTo(max) < 0) return;
        var v = min;
        min=max;
        max=v;
    }

    public static int Int32(int? min = null, int? max = null) {
        var minVal = min ?? -1000;
        var maxVal = max ?? 1000;
        minFirst(ref minVal, ref maxVal);
        return Random.Shared.Next(minVal, maxVal);
    }

    public static double Double(double? min = null, double? max = null) {
        var minVal = min ?? -1000.0;
        var maxVal = max ?? 1000.0;
        minFirst(ref minVal, ref maxVal);
        return minVal + Random.Shared.NextDouble() * (maxVal - minVal);
    } 
    public static char Char(char min = char.MinValue, char max = char.MaxValue) => (char)Int32(min, max);
    public static bool Bool() => Int32() % 2 == 0;
    public static DateTime DateTime(ushort minYear = 1900, ushort maxYear = 2100)
    {
        var years = Int32(minYear, maxYear - 1);
        var days = Int32(1, 364);
        var seconds = Int32(1, 24 * 60 * 60);
        var d = new DateTime(years);
        d = d.AddDays(days);
        d = d.AddSeconds(seconds);
        return d;
    }
    public static string String(ushort minLength = 5, ushort maxLength = 30)
    {
        var s = string.Empty;
        var length = Int32(minLength, maxLength);
        for (var i = 0; i < length; i++) s += Char('a', 'z');
        return s;
    }
    public static dynamic Value<T>(T? min=default, T? max=default)
    {
        if (typeof(T) == typeof(bool)) return Bool();
        else if (typeof(T) == typeof(bool?)) return Bool();
        else if (typeof(T) == typeof(DateTime)) return DateTime();
        else if (typeof(T) == typeof(DateTime?)) return DateTime();
        else if (typeof(T) == typeof(double?)) return Double(Convert.ToDouble(min), Convert.ToDouble(max));
        else if (typeof(T) == typeof(double)) return Double(Convert.ToDouble(min), Convert.ToDouble(max));
        else if (typeof(T) == typeof(int?)) return Int32(Convert.ToInt32(min), Convert.ToInt32(max));
        else if (typeof(T) == typeof(int)) return Int32(Convert.ToInt32(min), Convert.ToInt32(max));
        else if (typeof(T) == typeof(char?)) return Char(Convert.ToChar(min), Convert.ToChar(max));
        else if (typeof(T) == typeof(char)) return Char(Convert.ToChar(min), Convert.ToChar(max));
        else return String();
    }
}