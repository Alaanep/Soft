using System;
using ABC.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Aids;

[TestClass] public class GetRandomTests : IsTypeTested
{
    private void test<T>(T min, T max) where T: IComparable<T> {
        var x = GetRandom.Value(min, max);
        var y = GetRandom.Value(min, max);
        isInstanceOfType(x, typeof(T));
        isInstanceOfType(y, typeof(T));
        isTrue(x >= (min.CompareTo(max) < 0 ? min: max));
        isTrue(y >= (min.CompareTo(max) < 0 ? min : max));
        isTrue(x <= (min.CompareTo(max) < 0 ? max : min));
        isTrue(y <= (min.CompareTo(max) < 0 ? max : min));
        areNotEqual(x, y);
    }

    [DataRow(-1000, 1000)]
    [DataRow(-1000, 0)]
    [DataRow(0, 1000)]
    [DataRow(int.MaxValue - 100, int.MaxValue)]
    [DataRow(int.MinValue, int.MinValue+100)]
    [DataRow(1000, -1000)]
    [TestMethod] public void Int32Test(int min, int max) {
        test(min, max);
    }

    [DataRow(-1000.0, 1000.0)]
    [DataRow(-1000.0, 0)]
    [DataRow(0, 1000.0)]
    [DataRow(double.MaxValue - 1.0E+308, double.MaxValue)]
    [DataRow(double.MinValue, double.MinValue + 1.0E+308)]
    [DataRow(1000.0, -1000.0)]
    [TestMethod] public void DoubleTest(double min, double max) {
        test(min, max);
    }
    [TestMethod] public void CharTest() => isInconclusive();
    [TestMethod] public void BoolTest() => isInconclusive();
    [TestMethod] public void DateTimeTest() => isInconclusive();
    [TestMethod] public void StringTest() => isInconclusive();
    [TestMethod] public void ValueTest() => isInconclusive();
}