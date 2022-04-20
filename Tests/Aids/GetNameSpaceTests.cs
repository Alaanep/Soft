using ABC.Aids;
using ABC.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Aids;

[TestClass] public class GetNameSpaceTests : TypeTests {
    [TestMethod] public void OfTypeTest() {
        var obj = new CurrencyData();
        var name = obj.GetType().Namespace;
        var n = GetNameSpace.OfType(obj);
        areEqual(name,n);
    }

    [TestMethod] public void OfTypeNullTest()
    {
        CurrencyData? obj = null;
        var n = GetNameSpace.OfType(obj);
        areEqual(string.Empty, n);
    }
}