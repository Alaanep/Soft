using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests;

public abstract class TestAsserts
{
    protected static void inconclusive() => Assert.Inconclusive();
    protected static void isNotNull([NotNull] object? o = null) => Assert.IsNotNull(o);
    protected static void areEqual(object? expected, object? actual) => Assert.AreEqual(expected, actual);
}