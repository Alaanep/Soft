using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests;

public abstract class TestAsserts
{
    protected static void isInconclusive(string? s=null) => Assert.Inconclusive(s ?? string.Empty);
    protected static void isNotNull([NotNull] object? o = null, string? message = null) => Assert.IsNotNull(o, message);
    protected static void isNull(object? o = null, string? message = null) => Assert.IsNull(o, message);
    protected static void areEqual(object? expected, object? actual, string? message = null) => Assert.AreEqual(expected, actual, message);
    protected static void areNotEqual(object? expected, object? actual, string? message = null) => Assert.AreNotEqual(expected, actual, message);
    protected static void isInstanceOfType(object o, Type expectedType, string? message = null) => Assert.IsInstanceOfType(o, expectedType, message);
    protected static void isTrue(bool? b, string? message=null) => Assert.IsTrue(b ?? false, message ?? string.Empty);
    protected static void isFalse(bool? b, string? message = null) => Assert.IsFalse(b ?? true, message ?? string.Empty);

    protected virtual void areEqualProperties(object? a, object? b) {
        isNotNull(a);
        isNotNull(b);
        var tA = a.GetType();
        var tB = b.GetType();
        
        foreach (var propertyInfoA in tA?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
            var vA = propertyInfoA.GetValue(a, null);
            var propertyInfoB = tB?.GetProperty(propertyInfoA.Name);
            var vB = propertyInfoB?.GetValue(b, null);
            areEqual(vA, vB, $"For property {propertyInfoA.Name}.");
        }
    }

}